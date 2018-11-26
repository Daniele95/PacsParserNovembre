﻿using ExplorerManager;
using System.Windows;
using FolderBrowser.ViewModel;
using FileListView;
using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Utilities;
using System.Windows.Controls;

namespace ExplorerTools
{
    public partial class Main : Window
    {

        public explorerManager manager = new explorerManager();

        public studyLevelQuery currentStudyToDownload;
        public seriesLevelQuery currentSeriesToDownload;

        QueryWindow queryWindow;
        SeriesFound seriesFoundPage;

        FileBrowser f;

        public Main()
        {
            InitializeComponent();
            queryWindow = new QueryWindow(this);
            seriesFoundPage = new SeriesFound();
            manager.studyArrived += onStudyQueryArrived;
            manager.seriesArrived += onSeriesQueryArrived;
        }

        void explorerClick(object o, RoutedEventArgs e)
        {
            f = new FileBrowser();
            frame.NavigationService.Navigate(f);
        }
        void queryClick(object o, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(queryWindow);
        }
        void downloadClick(object o, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(seriesFoundPage);
        }

        // ------------------QUERY WINDOW------------------------------

        public void onSearchButtonClicked()
        {
            queryWindow.stackPanel.Children.Clear();
            manager.onButtonPressed(queryWindow.inputBox.Text);
        }

        public void onStudyQueryArrived(studyLevelQuery queryResults)
        {
            string resultText = "";
            resultText = queryResults.PatientName + " " + queryResults.StudyDate + " " + queryResults.PatientID + "\n";

            this.Dispatcher.Invoke(() => {

                Button result = new Button();
                result.Content = resultText;

                // if button pressed, do a retrieval of the series in that study
                currentStudyToDownload = queryResults;
                result.Click += (sender, e) => { onStudyButtonClicked(queryResults); };

                queryWindow.stackPanel.Children.Add(result);
            });

        }

        // search all series of a study
        public void onStudyButtonClicked(studyLevelQuery queryResults)
        {
            seriesFoundPage.stackPanel.Children.Clear();
            manager.onStudyButtonPressed(queryResults);
            frame.NavigationService.Navigate(seriesFoundPage);
        }

        // add found series to series list 
        public void onSeriesQueryArrived(seriesLevelQuery queryResults)
        {
            Dispatcher.Invoke(() => {
                Button result = new Button();
                result.Content = queryResults.SeriesInstanceUID + "  "+ queryResults.SeriesDescription;
                result.Click += ((obj, evento) => {
                    //
                });
                seriesFoundPage.stackPanel.Children.Add(result);
            });
        }

        // ------------------------------------------------



        void readDicomDir()
        {
            string dir = @"C:\Users\daniele\Desktop\dicomDatabase";
            System.IO.StreamReader file = new System.IO.StreamReader(dir);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                line = Regex.Replace(line, @"[^\u0020-\u007F]", " ");


                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                line = regex.Replace(line, " ");
                line = line.Replace(" U", System.Environment.NewLine +" U");


                Console.WriteLine(line);
                string[] parts = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

    }
}