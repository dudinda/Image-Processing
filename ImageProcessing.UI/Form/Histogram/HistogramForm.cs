using ImageProcessing.Presentation.Views.Histogram;

using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.Form.Histogram
{
    public partial class HistogramForm : MetroForm, IHistogramView
    {
        private readonly ApplicationContext _context;

        public HistogramForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            Freq.ChartAreas[0].AxisX.Minimum = 0;
            Freq.ChartAreas[0].AxisX.Maximum = 255;
            Freq.ChartAreas[0].AxisX.Interval = 50;
        }

        public event Action<Bitmap> BuildHistogram;
        public event Action<Bitmap> BuildCDF;

        public Chart GetChart => Freq;

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

      
        /*
        public void Init(string text, double[] pmf)
        {
            
            if (text.Equals("CDF"))
            {
                this.Text = "F(x)";
                Freq.Series["F(x)"].IsVisibleInLegend = true;
                Freq.Series["p(x)"].IsVisibleInLegend = false;
            }
            else
            {
                this.Text = "p(x)";
                Freq.Series["p(x)"].IsVisibleInLegend = true;
                Freq.Series["F(x)"].IsVisibleInLegend = false;
            }
            Freq.Legends["Legend1"].CustomItems[0].Name += string.Format($" = {DistributionContext.GetExpectation(pmf).ToString()}");
            Freq.Legends["Legend1"].CustomItems[1].Name += string.Format($" = {DistributionContext.GetStandardDeviation(pmf).ToString()}");
        }
       
        */
    }
}
