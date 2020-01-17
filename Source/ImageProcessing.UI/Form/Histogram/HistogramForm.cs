using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Presentation.Views.Histogram;

using MetroFramework.Forms;

namespace ImageProcessing.Form.Histogram
{
    public partial class HistogramForm : MetroForm, IHistogramView
    {
        public HistogramForm()
        {
            InitializeComponent();
        }

        public Chart GetChart => Freq;

        public new void Show()
        {
            ShowDialog();
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
