using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Presentation.Views.QualityMeasure;

using MetroFramework.Forms;

namespace ImageProcessing.Form.QualityMeasure
{
    public partial class QualityMeasureForm : MetroForm, IQualityMeasureView
    {
        public QualityMeasureForm()
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

