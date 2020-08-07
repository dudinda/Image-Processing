using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Distribution;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Distribution
{
    /// <inheritdoc cref="IDistributionView"/>
    internal sealed partial class DistributionForm : BaseForm, IDistributionFormExposer
    {
        private readonly IDistributionFormEventBinder _binder;

        public DistributionForm(
            IAppController controller,
            IDistributionFormEventBinder binder) : base(controller)
        {
            InitializeComponent();

            var values = default(Distributions)
                .GetAllEnumValues()
                .Select(val => val.GetDescription())
                .ToArray();

            DistributionsComboBox.Items.AddRange(
                 Array.ConvertAll(values, item => (object)item)
             );

            DistributionsComboBox.SelectedIndex = 0;

            _binder = binder;

            _binder.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        /// <inheritdoc/>
        public Distributions Dropdown
        {
            get => DistributionsComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<Distributions>();
        }

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public MetroButton ApplyTransformButton
            => Transform;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton CdfButton
            => CDF;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton PmfButton
            => PMF;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton ExpectactionButton
            => Expectation;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton VarianceButton
            => Variance;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton DeviationButton
            => StandardDeviation;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton EntropyButton
            => Entropy;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton ShuffleButton
            => ShuffleSrc;

        /// <inheritdoc cref="IDistributionFormExposer"/>
        public ToolStripButton QualityButton
            => QualityMeasure;

        /// <inheritdoc/>
        public void Tooltip(string message)
             => ErrorToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000
             );

        /// <inheritdoc/>
        public void EnableQualityQueue(bool isEnabled)
            => QualityMeasure.Enabled = isEnabled;

        /// <inheritdoc/>
        public void AddToQualityMeasureContainer(Bitmap transformed)
            => QualityMeasure.TryAdd(transformed);

        /// <inheritdoc/>
        public ConcurrentQueue<Bitmap> GetQualityQueue()
            => QualityMeasure.Queue;

        /// <inheritdoc/>
        public void ClearQualityQueue()
            => QualityMeasure.Reset();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
                .Unsubscribe(typeof(DistributionPresenter), this);

            base.Dispose(true);
        }
    }
}
