using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.UILayer.Form.Histogram
{
    /// <inheritdoc cref="IHistogramView"/>
    internal sealed partial class HistogramForm : BaseForm, IHistogramView
    {
        public HistogramForm(IAppController controller)
            : base(controller)
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        public Chart DataChart
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

        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            Controller
               .Aggregator
               .Unsubscribe(typeof(HistogramPresenter), this);

            base.Dispose(true);
        }
    }
}
