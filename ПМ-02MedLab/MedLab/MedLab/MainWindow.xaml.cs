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
using System.Windows.Threading;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public int cout = 3;
        public int cout1 = 60;
        private void BtnStartWindw(object sender, RoutedEventArgs e)
        {

            try
            {

                using (var db = new MedlabEntities())
                {
                  

                    var user = db.users.FirstOrDefault(s => s.login == LogTB.Text && s.password == PasTB.Password);
                    if (user != null && CapTB.Text==CapTB1.Text)
                    {
                        switch (user.type)
                        {
                            case 1:
                                StartWindow startWindow = new StartWindow();
                                startWindow.Show();
                                startWindow.NameUser.Content = user.name;
                                this.Close();
                                break;
                            case 2:
                                LabWindow labwindow = new LabWindow();
                                labwindow.Show();
                                labwindow.NameUser.Content = user.name;
                                this.Close();
                                break;
                            case 3:
                                BuhgWindow buhgwindow = new BuhgWindow();
                                buhgwindow.Show();
                                buhgwindow.NameUser.Content = user.name;
                                this.Close();
                                break;
                        }
                    }
                    else
                    {
                        
                        MessageBox.Show("Логин или пароль не верен");
                        CapTB1.Text = captcha();
                        cout--;
                        
                        MessageBox.Show("Осталось попыток" + " "+cout.ToString());
                        if (cout == 0)
                        {
                            Timer timer = new Timer();
                            timer.ShowDialog();
                            cout = 3;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подлкючения к БД");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegWindow RW = new RegWindow();
            RW.Show();
            this.Close();
        }
        public string captcha()
        {
            Random rnd = new Random();
            char[] z = {'0','1','2','3','4','5','6','7','8','9','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

            string captcha = "";

            for (int i = 0; i != 7; i++)
            {
                int j = rnd.Next(0, 60);
                captcha += z[j];
            }
            return captcha;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CapTB1.Text = captcha();
        }

        private void CapTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
