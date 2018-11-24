using ExplorerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Explorer
{
    public partial class MainWindow : Window
    {
        public int a = 0;
        explorerManager ExplorerManager;

        public MainWindow()
        {
            ExplorerManager = new explorerManager();
            ExplorerManager.Event += onQueryArrived;
            InitializeComponent();
        }

        private void onSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            ExplorerManager.onButtonPressed();
        }

        private void onQueryArrived(string a)
        {
            resultsTextBox.Text = "risultati arrivati!!";
        }
    }
}
