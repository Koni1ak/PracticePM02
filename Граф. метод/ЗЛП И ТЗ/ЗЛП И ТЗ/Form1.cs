using System.Windows.Forms.DataVisualization.Charting;

namespace ЗЛП_И_ТЗ
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 400;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 400;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 400;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 400;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            double[,] constraints = new double[3, 3]
            {
                { 2, 1, -10 },
                { -2, 3, -6 },
                { 2, 4, 8 }
            };

           
            Series polygonSeries = new Series();
            polygonSeries.ChartType = SeriesChartType.Line;
            polygonSeries.BorderWidth = 2;
            polygonSeries.Color = Color.Blue;

            
            for (int i = 0; i < constraints.GetLength(0); i++)
            {
                double a = constraints[i, 0];
                double b = constraints[i, 1];
                double c = constraints[i, 2];

                double x1 = (double)c / -a;
                double y1 = 0;

                if (b != 0)
                {
                    x1 = 0;
                    y1 = (double)c / -b;
                }

                
                Random random = new Random();
                double x2 = random.Next(400);
                double y2 = random.Next(400);

                polygonSeries.Points.Add(new DataPoint(x1, y1));
                polygonSeries.Points.Add(new DataPoint(x2, y2));
            }

         
            chart2.Series.Clear();
            chart2.Series.Add(polygonSeries);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            
            double[,] constraints = new double[3, 3]
            {
                { 1, 2, 4 },
                { 1, 3, 3 },
                { 2, 1, 8 }
            };

            
            Series polygonSeries = new Series();
            polygonSeries.ChartType = SeriesChartType.Line;
            polygonSeries.BorderWidth = 2;
            polygonSeries.Color = Color.Blue;

            
            for (int i = 0; i < constraints.GetLength(0); i++)
            {
                double a = constraints[i, 0];
                double b = constraints[i, 1];
                double c = constraints[i, 2];

                double x1 = (double)c / -a;
                double y1 = 0;

                if (b != 0)
                {
                    x1 = 0;
                    y1 = (double)c / -b;
                }

                
                Random random = new Random();
                double x2 = random.Next(400);
                double y2 = random.Next(400);

                polygonSeries.Points.Add(new DataPoint(x1, y1));
                polygonSeries.Points.Add(new DataPoint(x2, y2));
            }

            
            chart1.Series.Clear();
            chart1.Series.Add(polygonSeries);
        }
    }
}

    

    

