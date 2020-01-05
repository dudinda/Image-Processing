using ImageProcessing.Presentation.Views.Histogram;

using MetroFramework.Forms;

using System.Drawing;

namespace ImageProcessing
{
    public partial class HistogramForm : MetroForm, IHistogramView
    {
        public HistogramForm()
        {
            InitializeComponent();
            Freq.ChartAreas[0].AxisX.Minimum = 0;
            Freq.ChartAreas[0].AxisX.Maximum = 255;
            Freq.ChartAreas[0].AxisX.Interval = 50;
        }

        public void BuildHistogram(Bitmap bitmap)
        {
            Freq.ChartAreas[0].AxisY.MaximumAutoSize = true;
            var frequencies = DistributionContext.GetFrequencies(bitmap);
            var pmf = DistributionContext.GetPMF(frequencies, bitmap.Width * bitmap.Height);

            Init("PMF", pmf);

            for(int graylevel = 0; graylevel < 256; ++graylevel)
            {
                    Freq.Series["p(x)"].Points.AddXY(graylevel, pmf[graylevel]);
            }


        }

        public void BuildCDF(Bitmap bitmap)
        {

            Freq.ChartAreas[0].AxisY.Maximum = 1;
            var frequencies = DistributionContext.GetFrequencies(bitmap);
            var pmf = DistributionContext.GetPMF(frequencies, bitmap.Width * bitmap.Height);
            var cdf = DistributionContext.GetCDF(pmf);

            Init("CDF", pmf);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                Freq.Series["F(x)"].Points.AddXY(graylevel, cdf[graylevel]);
            }

           
        }

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
       
        
    }
}
