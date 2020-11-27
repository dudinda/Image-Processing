using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

using static ImageProcessing.App.CommonLayer.Enums.RgbChannels;

namespace ImageProcessing.App.UILayer.Form.Rgb
{
    internal sealed partial class RgbForm : BaseForm,
        IRgbFormExposer, IRgbView
    {
        private readonly IRgbFormEventBinder _binder;

        public RgbForm(
            IAppController controller,
            IRgbFormEventBinder binder) : base(controller)
        {
            InitializeComponent();

            PopulateComboBox<RgbFltr>(RgbFilterComboBox);

            _binder = binder;
            _binder.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public RgbFltr Dropdown
        {
            get => RgbFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RgbFltr>();
        }

        /// <inheritdoc/>
        public MetroCheckBox RedButton
            => RedColor;

        /// <inheritdoc/>
        public MetroCheckBox GreenButton
            => GreenColor;

        /// <inheritdoc/>
        public MetroCheckBox BlueButton
            => BlueColor;

        /// <inheritdoc/>
        public MetroButton ApplyFilterButton
            => ApplyFilter;

        /// <inheritdoc/>
        public MetroButton ColorMatrixMenuButton
            => ColorMatrixMenu;
             
        /// <inheritdoc/>
        public void Tooltip(string message)
           => ShowToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000);

        /// <inheritdoc/>
        public RgbChannels GetSelectedChannels(RgbChannels channel)
        {
            var result = Unknown;

            if (RedButton.Checked) { result |= Red; }
            if (BlueButton.Checked) { result |= Blue; }
            if (GreenButton.Checked) { result |= Green; }

            if (result == Unknown)
            {
                result |= Green | Blue | Red;
            }

            return result;
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
               .Unsubscribe(typeof(RgbPresenter), this);

            base.Dispose(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
