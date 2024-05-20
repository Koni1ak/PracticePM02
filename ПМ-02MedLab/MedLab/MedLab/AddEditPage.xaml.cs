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

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Услуги_лаборатории _currenUsl = new Услуги_лаборатории();
        public AddEditPage(Услуги_лаборатории SelectedUsl)
        {
            InitializeComponent();
            if (SelectedUsl != null)
                _currenUsl = SelectedUsl;
            DataContext = _currenUsl;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currenUsl.id.ToString()))
                errors.AppendLine("Укажите код пробирки");
            if (_currenUsl.Наименование == null)
                errors.AppendLine("Укажите наименование");
            if (_currenUsl.Стоимость == null)
                errors.AppendLine("Укажите стоимость");
            if (_currenUsl.Срок_выполнения == null)
                errors.AppendLine("укажите срок выполнения");
            if (_currenUsl.Среднее_отклонение == null)
                errors.AppendLine("Укажите среднее отклонение");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenUsl.id == 0)
                MedlabEntities.GetContext().Услуги_лаборатории.Add(_currenUsl);
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
