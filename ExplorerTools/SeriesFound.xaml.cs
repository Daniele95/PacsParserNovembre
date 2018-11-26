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
using Utilities;

namespace ExplorerTools
{
    /// <summary>
    /// Interaction logic for SeriesFound.xaml
    /// </summary>
    public partial class SeriesFound : Page
    {
        public seriesLevelQuery queryResults;

        public SeriesFound()
        {
            InitializeComponent();
        }
        void Window_Load(object o, RoutedEventArgs e)
        {

            Button result = new Button();
            result.Content = queryResults.SeriesInstanceUID;
            result.Click += ((obj, evento) => {
                // if button pressed, do a retrieval of the series in that study
                Console.WriteLine("ciao");
            });
            stackPanel.Children.Add(result);
        }
    }
}
