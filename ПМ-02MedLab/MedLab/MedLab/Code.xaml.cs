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
using System.IO;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp;
using PdfSharp.Pdf;



namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Window
    {
        public Code()
        {
            InitializeComponent();
        }

        public double transalte(int width)
        {
            double razmer = 0.569;

            return razmer *= width;
        }
        private void CodeBtn_Click(object sender, RoutedEventArgs e)
        {
            string stroka = CodeTB.Text;
            double x = 0;

            if (CodeTB.Text == "")
            {
                Panel.Children.Clear();
            }
            codelab.Content = CodeTB.Text;
            foreach (var c in stroka)
            {
                try
                {
                    x = 10;
                    Line vert = new Line();

                    vert.X1 = 0 + x;
                    vert.Y1 = 0;
                    vert.X2 = 0 + x;
                    vert.Y2 = 55;

                    if (c == '0')
                    {
                        vert.Stroke = new SolidColorBrush(Colors.White);

                        vert.StrokeThickness = 5.12;

                        Panel.Children.Add(vert);
                    }
                    else
                    {
                        vert.Stroke = new SolidColorBrush(Colors.Black);
                        string j = c.ToString();
                        int f = Convert.ToInt32(j);
                        vert.StrokeThickness = transalte(f);

                        Panel.Children.Add(vert);
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректно");
                    break;
                }
            } 
        }

        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void formMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "FilePDF";
            if (codelab.Content == "")
            {
                MessageBox.Show("Введите код");
            }

            else
            {
                if (save.ShowDialog() == true)
                {
                    //var doc = new Document();
                    //PdfWriter.GetInstance(doc, new FileStream(save.FileName + ".pdf", FileMode.Create));
                    //doc.Open();

                    //PdfPTable table = new PdfPTable(3);
                    //PdfPCell cell = new PdfPCell(new Phrase(CodeTB.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, iTextSharp.text.Font.NORMAL)));

                    //cell.Padding = 5;
                    //cell.Colspan = 3;
                    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //table.AddCell(cell);

                    //cell = new PdfPCell(new Phrase());
                    //doc.Add(table);
                    //doc.Close();

                }
                
            }
        }    
    }
}
