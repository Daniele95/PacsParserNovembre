using ExplorerManager;
using System.Windows;
using FolderBrowser.ViewModel;
using FileListView;


namespace ExplorerTools
{
    public partial class Main : Window
    {

        public explorerManager manager = new explorerManager();

        FileBrowser f;
        QueryWindow q;
        SeriesFound s = new SeriesFound();
         
        public Main()
        {
            InitializeComponent();
            q = new QueryWindow(manager);
        }

        void explorerClick(object o, RoutedEventArgs e)
        {
            f = new FileBrowser();
            frame.NavigationService.Navigate(f);

        }
        void queryClick(object o, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(q);

        }
        void downloadClick(object o, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(s);

        }

    }
}