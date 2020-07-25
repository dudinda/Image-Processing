using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.UILayer.Form.Histogram
{
    /// <inheritdoc cref="IHistogramView"/>
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        private static readonly Dictionary<string, CommandAttribute>
          _command = typeof(HistogramForm).GetCommands();

        public HistogramForm(IAppController controller)
            : base(controller)
        {
            InitializeComponent();
        }

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
        public void Init(RandomVariableFunction function)
        {
            _command[
                function.ToString()
            ].Method.Invoke(this, new object[] {
                RandomVariableFunction.PMF.GetDescription(),
                RandomVariableFunction.CDF.GetDescription()
            });
        } 
        
        [Command(nameof(RandomVariableFunction.CDF))]
        private void SetupCDFCommand(string pmf, string cdf)
        {          
            Text = cdf;
            Freq.Series[cdf].IsVisibleInLegend = true;
            Freq.Series[pmf].IsVisibleInLegend = false;
        }

        [Command(nameof(RandomVariableFunction.PMF))]
        private void SetupPMFCommand(string pmf, string cdf)
        {
            Text = pmf;
            Freq.Series[pmf].IsVisibleInLegend = true;
            Freq.Series[cdf].IsVisibleInLegend = false;
        }

        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            base.Dispose(true);
        }
    }
}
