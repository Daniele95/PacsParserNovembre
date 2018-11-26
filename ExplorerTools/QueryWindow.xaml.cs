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
        public Main mainWindow;

        public QueryWindow(Main mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }
        private void onSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            mainWindow.onSearchButtonClicked();
        }



        }
}
