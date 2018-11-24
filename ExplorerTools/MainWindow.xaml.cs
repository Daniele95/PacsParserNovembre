using ExplorerManager;
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

namespace ExplorerTools
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
            // resultsTextBox.Text = "risultati arrivati!!";
        }
    }
}