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
    public partial class Query : Page
    {
        public int a = 0;
        explorerManager ExplorerManager;

        public Query()
        {
            ExplorerManager = new explorerManager();
            ExplorerManager.Event += onQueryArrived;
            InitializeComponent();
            // frame.NavigationService.Navigate(new Page1());

            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Show();

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
                    ExplorerManager.onStudyButtonPressed(queryResults);
                });
                stackPanel.Children.Add(result);

                //Button studyDownload = 
            });

        }

    }
}
