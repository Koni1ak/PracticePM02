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
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.Pdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using System.IO;

namespace MedLab.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuhPage.xaml
    /// </summary>
    public partial class BuhPage : Page
    {
        public BuhPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MedlabEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = MedlabEntities.GetContext().Выставленые_счета_страховой_компании.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrameBuh.Navigate(new MedLab.Pages.AddEditPage2((sender as Button).DataContext as Выставленые_счета_страховой_компании));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrameBuh.Navigate(new MedLab.Pages.AddEditPage2(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BluForRemoving = DGrid.SelectedItems.Cast<Выставленые_счета_страховой_компании>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие{BluForRemoving.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    MedlabEntities.GetContext().Выставленые_счета_страховой_компании.RemoveRange(BluForRemoving);
                    MedlabEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = MedlabEntities.GetContext().Выставленые_счета_страховой_компании.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }



        private void Export_Click(object sender, RoutedEventArgs e)
        {
            //string extension = "pdf";

            //SaveFileDialog dialog = new SaveFileDialog()
            //{
            //    DefaultExt = extension,
            //    Filter = String.Format("{1} files (.{0})|.{0}|All files (.)|.", extension, "Pdf"),
            //    FilterIndex = 1
            //};

            //if (dialog.ShowDialog() == true)
            //{
            //    using (Stream stream = dialog.OpenFile())
            //    {
            //        gridViewExport.ExportToPdf(stream,
            //            new GridViewPdfExportOptions()
            //            {
            //                ShowColumnFooters = true,
            //                ShowColumnHeaders = true,
            //                ShowGroupFooters = true,
            //                PageOrientation = PageOrientation.Landscape
            //            });
            //    }
            //}
            //var document = Dgrid1.ExportToPdf();

            //document.Save("Sample.pdf");
            //SaveFileDialog save = new SaveFileDialog();
            //save.FileName = "Export.pdf";
            //save.Filter = "Export (*pdf)|*.pdf";
            //Export exp = new Export();
            //if (save.ShowDialog()==true)
            //{
            //    exp.ExportToPdf(DGrid, save.FileName);
            //}

        }
    }
}
