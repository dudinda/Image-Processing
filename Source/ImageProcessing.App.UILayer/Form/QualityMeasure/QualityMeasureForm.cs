using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.UILayer.Form.Base;

namespace ImageProcessing.App.UILayer.Form.QualityMeasure
{
    internal sealed partial class QualityMeasureForm : BaseForm, IQualityMeasureView
    {
        public QualityMeasureForm(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            InitializeComponent();
            SetHistogram();     
        }

        public Chart GetChart => Histogram;

        public new void Show()
        {
            Focus();
            base.Show();
        }

        private void SetHistogram()
            => Histogram.Series.Clear();    
    }
}

