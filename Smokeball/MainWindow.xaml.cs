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
using WebScraper;

namespace Smokeball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGoogleService _googleScraper { get; }
        public MainWindow(IGoogleService googleScraper)
        {
            _googleScraper = googleScraper;           
            InitializeComponent();
            var parseResults = _googleScraper.Scrape(new ScrapeRequest("conveyancing software", "www.smokeball.com.au", 100));
            if(parseResults == null || parseResults.Count==0)
            {
                ErrorMessage.Content = "Smokeball was not found in top 100 results";
                ErrorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                Result.Content = string.Join(", ", parseResults.Select(s => s.Position));
                Result.Visibility = Visibility.Visible;
                LabelResult.Visibility = Visibility.Visible;
            }
           
        }
      
    }
}
