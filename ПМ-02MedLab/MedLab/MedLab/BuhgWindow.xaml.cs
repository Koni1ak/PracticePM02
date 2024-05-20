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
using Syncfusion.Pdf;


namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для BuhgWindow.xaml
    /// </summary>
    public partial class BuhgWindow : Window
    {
        public BuhgWindow()
        {
            InitializeComponent();
            MainFrameBuh.Navigate(new Pages.BuhPage());
            Manager.MainFrameBuh = MainFrameBuh;
        }

        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void MainFrameBuh_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrameBuh.GoBack();
        }

    }
}
