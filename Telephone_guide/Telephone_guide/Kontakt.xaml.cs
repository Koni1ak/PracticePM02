using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Telephone_guide
{
    /// <summary>
    /// Логика взаимодействия для Kontakt.xaml
    /// </summary>
    public partial class Kontakt : Window
    {


        public IEnumerable<dynamic> phoneData;


        public Kontakt()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).ToList();
            // Обновить данные в датагриде
            dat1.ItemsSource = phoneData;
        }

        //редактирование контакта
        private void red_Click(object sender, RoutedEventArgs e)
        {

            // Включаем режим редактирования
            dat1.IsReadOnly = false;
        }
       
        
        //сохранение изменений
        private void sohr_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //удаление контакта
        private void delete_Click(object sender, RoutedEventArgs e)
        {
           Справочник_номеровEntities bd = new Справочник_номеровEntities();
            if (dat1.SelectedItem != null)
            {
                var selectedRow = dat1.SelectedItem as dynamic;

                // Удаляем запись из коллекции
                phoneData.ToList().Remove(selectedRow);

                // Удаляем запись из базы данных
                bd.Контакты.Remove(bd.Контакты.Find(selectedRow.ID_контакта));

                // Сохраняем изменения
                bd.SaveChanges();
            }

        }

            //сортировка имени по убыванию
            private void imub_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).OrderByDescending(p => p.Имя).ToList();
            // Обновить данные в датагриде
            dat1.ItemsSource = phoneData;
        }

        //сортировка имени по возрастанию
        private void imvozr_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).OrderBy(p => p.Имя).ToList();
            // Обновить данные в датагриде
            dat1.ItemsSource = phoneData;
        }

        //экспорт в ксв
        private void CSV_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса StringBuilder для построения содержимого CSV-файла
            StringBuilder csvData = new StringBuilder();

            // Добавление заголовков столбцов в первую строку
            csvData.AppendLine("Фамилия,Имя,Отчество,Номер телефона,Электронная почта,Дата рождения,Компания,Должность,Группа контактов");

            // Перебор данных и добавление строк в CSV-файл
            foreach (var row in phoneData)
            {
                csvData.AppendLine($"{row.Фамилия},{row.Имя},{row.Отчество},{row.Номер_телефона},{row.Электронная_почта},{row.Дата_рождения},{row.Компания},{row.Должность},{row.Группа_контактов}");
            }

            // Создание диалогового окна "Сохранить файл"
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.FileName = "exported_contacts.csv";

            // Показ диалогового окна и получение имени файла, если пользователь выбрал "Сохранить"
            if (saveFileDialog.ShowDialog() == true)
            {
                // Запись содержимого CSV-файла в выбранный файл
                File.WriteAllText(saveFileDialog.FileName, csvData.ToString());

                MessageBox.Show("Данные успешно экспортированы в CSV-файл.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //выделение цветом группы семья
        private void chvet_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dat1.Items)
            {
                dynamic rowData = item;

                if (rowData.Группа_контактов == "Семья")
                {
                    DataGridRow row = dat1.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                    if (row != null)
                    {
                        row.Background = Brushes.LightGreen;
                    }
                }
            }

        }
       

        //сортировка по фамилии
        private void fam_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).OrderBy(p => p.Фамилия).ToList();
            // Обновить данные в датагриде
            dat1.ItemsSource = phoneData;
        }

        //фильтрация  по группе семья
        private void filtr_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             where gp.Название == "Семья"

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).ToList();
            // Обновить данные в датагриде
            dat1.ItemsSource = phoneData;
        }

        //Поиск контакта по части ФИО 
        private void поиск_Click(object sender, RoutedEventArgs e)
        {
            Справочник_номеровEntities bd = new Справочник_номеровEntities();
            string searchText = poisk.Text;

            var phoneData = (from p in bd.Контакты
                             join
                             d in bd.Должность on p.ID_должности equals d.ID_должности
                             join
                             c in bd.Компания on p.ID_компании equals c.ID_компании
                             join
                             gp in bd.Группа_контактов on p.ID_группы_контактов equals gp.ID_группы_контактов

                             where p.Фамилия.Contains(searchText) || p.Имя.Contains(searchText) || p.Отчество.Contains(searchText)

                             select new
                             {
                                 p.Фамилия,
                                 p.Имя,
                                 p.Отчество,
                                 p.Номер_телефона,
                                 p.Электронная_почта,
                                 p.Дата_рождения,
                                 Компания = c.Наименование,
                                 Должность = d.Наименование,
                                 Группа_контактов = gp.Название,
                             }).ToList();

            dat1.ItemsSource = phoneData;
        }

        
    }
    }
    

    

