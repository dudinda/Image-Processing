
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.UILayer.Form.Distribution;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class DistributionFormWrapper : IDistributionFormExposer, IDistributionView
    {
        private readonly IAutoResetEventService _synchronizer;
        private readonly DistributionForm _form;

        public DistributionFormWrapper(
           IAutoResetEventService synchronizer,
           IAppController controller,
           IDistributionFormEventBinder binder) 
        {
            _synchronizer = synchronizer;
            _form = new DistributionForm(controller, binder);
        }

        public virtual (string, string) Parameters
            => _form.Parameters;

        public virtual PrDistribution Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyTransformButton
            => _form.ApplyTransformButton;

        public virtual ToolStripButton CdfButton
            => _form.CdfButton;

        public virtual ToolStripButton PmfButton
            => _form.PmfButton;

        public virtual ToolStripButton ExpectactionButton
            => _form.ExpectactionButton;

        public virtual ToolStripButton VarianceButton
            => _form.VarianceButton;

        public virtual ToolStripButton DeviationButton
            => _form.DeviationButton;

        public virtual ToolStripButton EntropyButton
            => _form.EntropyButton;

        public virtual ToolStripButton ShuffleButton
            => _form.ShuffleButton;

        public virtual ToolStripButton QualityButton
            => _form.QualityButton;

        public virtual void AddToQualityMeasureContainer(Bitmap transformed)
            => _form.AddToQualityMeasureContainer(transformed);

        public virtual void Close()
            => _form.Close();

        public virtual void Dispose()
            => _form.Dispose();

        public virtual void EnableQualityQueue(bool isEnabled)
            => _form.EnableQualityQueue(isEnabled);

        public virtual ConcurrentQueue<Bitmap> GetQualityQueue()
            => _form.GetQualityQueue();

        public virtual void Show()
            => _synchronizer.Signal();

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
