using System;
using System.Linq;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Rgb
{
    internal sealed partial class RgbForm : BaseForm, IRgbFormExposer
    {
        private readonly IRgbFormCommand _command;
        private readonly IRgbFormEventBinder _binder;

        public RgbForm(
            IAppController controller,
            IRgbFormEventBinder binder,
            IRgbFormCommand command) : base(controller)
        {
            InitializeComponent();

            var values = default(RgbFilter)
                .GetAllEnumValues()
                .Select(val => val.GetDescription())
                .ToArray();

            RgbFilterComboBox.Items.AddRange(
                 Array.ConvertAll(values, item => (object)item)
             );

            RgbFilterComboBox.SelectedIndex = 0;

            _binder = binder;
            _command = command;

            _binder.OnElementExpose(this);
            _command.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public RgbFilter Dropdown
        {
            get => RgbFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RgbFilter>();
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
        public RgbColors GetSelectedColors(RgbColors color)
            => Read<RgbColors>(() => _command.GetSelectedColors(color));
                 
        /// <inheritdoc/>
        public void Tooltip(string message)
           => ShowToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000);

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
