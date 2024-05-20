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
using System.Windows.Shapes;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Window
    {
        public Timer()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            var timer1 = new System.Timers.Timer();

            timer1.Interval = 1000;
            timer1.Elapsed += dispatcherTimer_Tick;
            timer1.Start();
        }

        private void loadform(object sender, RoutedEventArgs e)
        {
            
        }
        public int cout1=30;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            cout1--;

            TB1.Dispatcher.Invoke(() => { TB1.Text = "Counter" + cout1; });
            
            
            if(cout1==0)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    this.Close();
                }));

            }
        }
    }
}
