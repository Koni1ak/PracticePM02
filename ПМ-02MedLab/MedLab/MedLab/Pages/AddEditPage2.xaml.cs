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
    /// Логика взаимодействия для AddEditPage2.xaml
    /// </summary>
    public partial class AddEditPage2 : Page
    {
        private Выставленые_счета_страховой_компании _currenBlu = new Выставленые_счета_страховой_компании();
        public AddEditPage2(Выставленые_счета_страховой_компании SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
            ComboGroup.ItemsSource = MedlabEntities.GetContext().ДанныеСтраховыхКомпаний.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currenBlu.ДанныеСтраховыхКомпаний == null)
                errors.AppendLine("Укажите страховую компанию");
            if (_currenBlu.Сумма == null)
                errors.AppendLine("Укажите сумму");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenBlu.id == 0)
                MedlabEntities.GetContext().Выставленые_счета_страховой_компании.Add(_currenBlu);
            try
            {
                MedlabEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrameBuh.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
