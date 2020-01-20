using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Common.Enums;
using ImageProcessing.Presentation.Views.Histogram;

using MetroFramework.Forms;

namespace ImageProcessing.Form.Histogram
{
    public partial class HistogramForm : MetroForm, IHistogramView
    {
        private readonly ApplicationContext _context;

        public HistogramForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public Chart GetChart => Freq;

        public new void Show()
        {
            Focus();
            base.Show();
        }
  
        public void Init(RandomVariable action)
        {
            switch(action)
            {
                case RandomVariable.PMF:
                    Text = "F(x)";
                    Freq.Series["F(x)"].IsVisibleInLegend = true;
                    Freq.Series["p(x)"].IsVisibleInLegend = false;
                    break;
                case RandomVariable.CDF:
                    Text = "p(x)";
                    Freq.Series["p(x)"].IsVisibleInLegend = true;
                    Freq.Series["F(x)"].IsVisibleInLegend = false;
                    break;

                default: throw new NotSupportedException(nameof(action));
            }                    
        }
       
    }
}
