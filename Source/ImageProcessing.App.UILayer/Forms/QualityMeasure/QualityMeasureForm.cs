using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.UILayer.Forms.QualityMeasure
{
    internal sealed partial class QualityMeasureForm : BaseForm,
        IQualityMeasureView
    {
        public QualityMeasureForm(IAppController controller)
            : base(controller)
        {
            InitializeComponent();
        }
        
        public Chart DataChart
            => Histogram;

        public new void Show()
        {
            Focus();
            base.Show();
        }

        /// <summary>
        /// Used by a DI container to dispose the singleton form
        /// on Release().
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            base.Dispose(true);
        }

        /// <summary>
        /// Restrict the generated <see cref="Dispose(bool)"/> call
        /// on a non-context form closing.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}

