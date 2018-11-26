using FolderBrowser.ViewModel;
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
using FileListView.Views;
using FileListView.ViewModels;
using ExplorerManager;

namespace ExplorerTools
{
    /// <summary>
    /// Interaction logic for FileExplorer.xaml
    /// </summary>
    public partial class FileBrowser : Page
    {


        public FileBrowser()
        {
            InitializeComponent();
         

            var dlg = new FolderBrowser.FolderBrowserDialog();

            var dlgViewModel = new DialogViewModel();
            dlgViewModel.TreeBrowser.SelectedFolder = @"C:\";

            dlg.DataContext = dlgViewModel;

           
             bool? bResult = dlg.ShowDialog();

             if (dlgViewModel.DialogCloseResult == true || bResult == true)
             System.Windows.MessageBox.Show("OPening path:" + dlgViewModel.TreeBrowser.SelectedFolder);

        }
    }
}
