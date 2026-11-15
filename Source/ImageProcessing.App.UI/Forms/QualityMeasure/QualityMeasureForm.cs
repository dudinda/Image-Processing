using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Services.FormEventBinders.QualityMeasure;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Forms.QualityMeasure
{
    internal partial class QualityMeasureForm : BaseForm,
        IQualityMeasureView, IQualityMeasureExposer
    {
        public QualityMeasureForm(IQualityMeasureEventBinder binder) : base()
        {
            InitializeComponent();
            binder.OnElementExpose(this);
            BringToFront();
        }
        
        public Chart DataChart
            => Read<Chart>(() => Histogram);

        public new void Show()
        {
            Focus();
            base.Show();
        }

        public new void Hide()
        {
            Controller
               .Aggregator
               .Unsubscribe(typeof(QualityMeasurePresenter), this);

            base.Hide();
        }

        public new void Close()
        {
            Hide();
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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Hide();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

