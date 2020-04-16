using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.UILayer.Form.QualityMeasure
{
    internal sealed partial class QualityMeasureForm : BaseForm, IQualityMeasureView
    {
        public QualityMeasureForm(IAppController controller)
            : base(controller)
        {
            InitializeComponent();
            SetHistogram();     
        }

        public Chart GetChart
            => Histogram;

        public new void Show()
        {
            Focus();
            base.Show();
        }

        private void SetHistogram()
            => Histogram.Series.Clear();    
    }
}

