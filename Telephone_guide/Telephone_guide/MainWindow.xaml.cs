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

namespace Telephone_guide
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            komp.Items.Add("1");
            komp.Items.Add("2");
            komp.Items.Add("3");
            komp.Items.Add("4");
            komp.Items.Add("5");
            komp.Items.Add("6");
            komp.Items.Add("7");
            komp.Items.Add("8");
            komp.Items.Add("9");
            komp.Items.Add("10");
            dolzh.Items.Add("1");
            dolzh.Items.Add("2");
            dolzh.Items.Add("3");
            dolzh.Items.Add("4");
            dolzh.Items.Add("5");
            dolzh.Items.Add("6");
            dolzh.Items.Add("7");
            dolzh.Items.Add("8");
            dolzh.Items.Add("9");
            dolzh.Items.Add("10");
            kont.Items.Add("1");
            kont.Items.Add("2");
            kont.Items.Add("3");
            kont.Items.Add("4");
            kont.Items.Add("5");
            kont.Items.Add("6");
            kont.Items.Add("7");
            kont.Items.Add("8");
            kont.Items.Add("9");
            kont.Items.Add("10");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Справочник_номеровEntities())
            {
                // Создаем новый контакт
                Контакты contact = new Контакты
                {
                    Фамилия = fam.Text,
                    Имя = name.Text,
                    Отчество = otc.Text,
                    Номер_телефона = tel.Text,
                    Электронная_почта = pochta.Text,
                    ID_компании = Convert.ToInt32(komp.SelectedValue),
                    ID_должности = Convert.ToInt32(dolzh.SelectedValue),
                    ID_группы_контактов = Convert.ToInt32(kont.SelectedValue),
                };
                if (!String.IsNullOrEmpty(dat.Text))
                {
                    contact.Дата_рождения = dat.SelectedDate.Value;
                }

                // Добавляем контакт в БД
                db.Контакты.Add(contact);

                // Сохраняем изменения
                db.SaveChanges();
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kontakt mw = new Kontakt();
            mw.Show();
            this.Close();
        }
    }
}
