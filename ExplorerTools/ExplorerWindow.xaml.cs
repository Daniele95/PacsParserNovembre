using ExplorerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Utilities;

namespace ExplorerTools
{
    public partial class ExplorerWindow : Window
    {
        public int a = 0;
        explorerManager ExplorerManager;

        public ExplorerWindow()
        {
            ExplorerManager = new explorerManager();
            ExplorerManager.Event += onQueryArrived;
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
            resultText = queryResults.PatientName+" "+ queryResults.StudyDate+"\n";

            this.Dispatcher.Invoke(() =>   {
                TextBlock resultsTextBlock = new TextBlock();
                resultsTextBlock.Text = resultText;
                stackPanel.Children.Add(resultsTextBlock);
            });
            
        }
        
    }
}