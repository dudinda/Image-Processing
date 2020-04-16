using System;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExtensions;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.DI.Controller.Interface;

namespace ImageProcessing.App.UILayer.Form.Histogram
{
    /// <inheritdoc cref="IHistogramView"/>
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        public HistogramForm(IAppController controller)
            : base(controller) => InitializeComponent();

        /// <inheritdoc/>
        public Chart GetChart
            => Freq;

        /// <inheritdoc/>
        public double YAxisMaximum 
        { 
            get => Freq.ChartAreas[0].AxisY.Maximum; 
            set => Freq.ChartAreas[0].AxisY.Maximum = value;    
        }

        /// <inheritdoc/>
        public new void Show()
        {
            Focus();
            base.Show();
        }

        /// <inheritdoc/>
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
