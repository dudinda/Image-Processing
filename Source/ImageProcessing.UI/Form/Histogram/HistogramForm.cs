using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Form.Base;
using ImageProcessing.Presentation.Views.Histogram;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.Form.Histogram
{
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        public HistogramForm(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            InitializeComponent();
        }

        public Chart GetChart => Freq;
        public double YAxisMaximum 
        { 
            get => Freq.ChartAreas[0].AxisY.Maximum; 
            set => Freq.ChartAreas[0].AxisY.Maximum = value;    
        }

        public new void Show()
        {
            Focus();
            base.Show();
        }
  
        public void Init(RandomVariable action)
        {
            var pmf = RandomVariable.PMF.GetDescription();
            var cdf = RandomVariable.CDF.GetDescription();
            switch (action)
            {
                case RandomVariable.CDF:
                    Text = cdf;
                    Freq.Series[cdf].IsVisibleInLegend = true;
                    Freq.Series[pmf].IsVisibleInLegend = false;
                    break;
                case RandomVariable.PMF:
                    Text = pmf;
                    Freq.Series[pmf].IsVisibleInLegend = true;
                    Freq.Series[cdf].IsVisibleInLegend = false;
                    break;

                default: throw new NotImplementedException(nameof(action));
            }                    
        }
       
    }
}
