using System;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Extensions.EnumExtensions;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.UILayer.Form.Base;

namespace ImageProcessing.App.UILayer.Form.Histogram
{
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        public HistogramForm(IEventAggregator eventAggregator)
            : base(eventAggregator) => InitializeComponent();
        
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
  
        public void Init(RandomVariableFunction action)
        {
            var pmf = RandomVariableFunction.PMF.GetDescription();
            var cdf = RandomVariableFunction.CDF.GetDescription();

            switch (action)
            {
                case RandomVariableFunction.CDF:
                    Text = cdf;
                    Freq.Series[cdf].IsVisibleInLegend = true;
                    Freq.Series[pmf].IsVisibleInLegend = false;
                    break;
                case RandomVariableFunction.PMF:
                    Text = pmf;
                    Freq.Series[pmf].IsVisibleInLegend = true;
                    Freq.Series[cdf].IsVisibleInLegend = false;
                    break;

                default: throw new NotImplementedException(nameof(action));
            }                    
        }
       
    }
}
