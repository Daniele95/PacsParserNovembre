using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExplorerManager;
using FolderBrowser;
using Utilities;

namespace ExplorerTools
{
    /// <summary>
    /// Interaction logic for Query.xaml
    /// </summary>
    public partial class QueryWindow : Page
    {
        explorerManager ExplorerManager;

        public QueryWindow(explorerManager e)
        {
            ExplorerManager = e;
            ExplorerManager.studyArrived += onQueryArrived;
            ExplorerManager.seriesArrived += onSeriesArrived;
            InitializeComponent();
        }

        private void onSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Clear();
            ExplorerManager.onButtonPressed(inputBox.Text);
        }

        private void onQueryArrived(studyLevelQuery queryResults)
        {
            string resultText = "";
            resultText = queryResults.PatientName + " " + queryResults.StudyDate + "\n";

            this.Dispatcher.Invoke(() => {
                Button result = new Button();
                result.Content = resultText;
                result.Click += ((o, e) => {
                    // if button pressed, do a retrieval of the series in that study
                    ExplorerManager.onStudyButtonPressed();
                });
                stackPanel.Children.Add(result);
                
            });

        }

        private void onSeriesArrived(seriesLevelQuery queryResults)
        {
              Dispatcher.Invoke(() =>
              {
                  SeriesFound seriesFoundPage = new SeriesFound();
                  seriesFoundPage.queryResults = queryResults;
                  this.NavigationService.Navigate(seriesFoundPage);
              });
        }

    }
}
