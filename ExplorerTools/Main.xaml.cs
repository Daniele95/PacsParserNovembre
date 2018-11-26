using ExplorerManager;
using System.Windows;
using FolderBrowser.ViewModel;
using FileListView;


namespace ExplorerTools
{
    public partial class Main : Window
    {
        public int a = 0;
        explorerManager ExplorerManager;

        public Main()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new FileExplorer());
        }


    }
}