using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Form.Base;
using ImageProcessing.Presentation.Views.QualityMeasure;

namespace ImageProcessing.Form.QualityMeasure
{
    public partial class QualityMeasureForm : BaseForm, IQualityMeasureView
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
        {
            Histogram.Series.Clear();
        }

    }
}

