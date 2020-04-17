using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExtensions;
using ImageProcessing.App.CommonLayer.Extensions.TypeExtensions;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.UILayer.Form.Histogram
{
    /// <inheritdoc cref="IHistogramView"/>
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        private static readonly Dictionary<string, CommandAttribute>
          _command = typeof(HistogramForm).GetCommands();

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

            _command[
                action.ToString()
            ].Method.Invoke(this, new object[] { pmf, cdf });
        } 
        
        [Command(nameof(RandomVariableFunction.CDF))]
        private void SetupCDF(string pmf, string cdf)
        {          
            Text = cdf;
            Freq.Series[cdf].IsVisibleInLegend = true;
            Freq.Series[pmf].IsVisibleInLegend = false;
        }

        [Command(nameof(RandomVariableFunction.PMF))]
        private void SetupPMF(string pmf, string cdf)
        {
            Text = pmf;
            Freq.Series[pmf].IsVisibleInLegend = true;
            Freq.Series[cdf].IsVisibleInLegend = false;
        }

    }
}
