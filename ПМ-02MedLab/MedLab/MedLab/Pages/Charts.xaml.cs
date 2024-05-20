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

using LiveCharts;
using LiveCharts.Wpf;

namespace MedLab.Pages
{
    /// <summary>
    /// Логика взаимодействия для Charts.xaml
    /// </summary>
    public partial class Charts : Page
    {
        
        public Charts()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                
                new LineSeries
                {
                    Title="PC",
                    Values = new ChartValues<int>{7,10,12,2,20}
                }
            };

            BarLabels = new[] { "10-10-2021", "02-06-2021", "11-12-2021", "10-01-2022", "15-03-2021" };
            Formatter = value => value.ToString("C");
            
            DataContext = this;
            
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }
        public Func<int, string> Formatter { get; set; }
    }
}
