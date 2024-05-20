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

namespace MedLab.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage1.xaml
    /// </summary>
    public partial class AddEditPage1 : Page
    {
        private Данные_анализатора _currenUsl = new Данные_анализатора();
        public AddEditPage1(Данные_анализатора SelectedUsl)
        {
            InitializeComponent();
            if (SelectedUsl != null)
                _currenUsl = SelectedUsl;
            DataContext = _currenUsl;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrWhiteSpace(_currenUsl.id.ToString()))
            //    errors.AppendLine("Укажите код анализатора");
            if (_currenUsl.Название == null)
                errors.AppendLine("Укажите название");
           

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenUsl.id == 0)
                MedlabEntities.GetContext().Данные_анализатора.Add(_currenUsl);
            try
            {
                MedlabEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
