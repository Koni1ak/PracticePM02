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

    public partial class LabWindow : Window
    {
        public LabWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new OkazUsl());
            Manager.MainFrame = MainFrame;
        }

        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void code_Click(object sender, RoutedEventArgs e)
        {
            Code code = new Code();
            code.Show();
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Anl_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AnlPage());
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();

        }

        private void Charts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Charts());
            Manager.MainFrame = MainFrame;
        }
    }
}
