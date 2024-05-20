using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.Pdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Data;

namespace MedLab
{
    internal class Export
    {
        public void ExportToPdf(DataGrid grid, string pathOfPdfWithFileName)
        {
            DataSet dataSet = new DataSet();
            DataGrid dataGrid = new DataGrid();

            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(grid.Columns.Count);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 150, 150, 62, 55);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(pathOfPdfWithFileName, System.IO.FileMode.Create));

            string FONT_LOCATION = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");


            doc.Open();


            for (int j = 0; j < 3; j++)
            {
                table.AddCell(new Phrase(grid.Columns[j].Header.ToString()));
            }
            table.HeaderRows = 1;
            IEnumerable<DataGrid> itemsSource = grid.ItemsSource as IEnumerable<DataGrid>;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < grid.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            DataGridTextColumn txt = cell.Content as DataGridTextColumn;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(cell.Content.ToString()));
                            }
                        }
                    }
                }


                doc.Add(table);


                doc.Close();
            }
        }
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
