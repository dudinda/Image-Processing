using System;
using System.Linq;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.ElementCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.EventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormControls.Rgb;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Rgb
{
    internal sealed partial class RgbForm : BaseForm, IRgbElementExposer
    {
        private readonly IRgbElementCommand _command;
        private readonly IRgbElementEventBinder _binder;

        public RgbForm(
            IAppController controller,
            IRgbElementEventBinder binder,
            IRgbElementCommand command) : base(controller)
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

            _binder.Expose(this);
            _command.Expose(this);
        }

        /// <inheritdoc/>
        public RgbFilter Dropdown
        {
            get => RgbFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RgbFilter>();
        }

        /// <inheritdoc/>
        public MetroRadioButton RedButton
            => RedColor;

        /// <inheritdoc/>
        public MetroRadioButton GreenButton
            => RedColor;

        /// <inheritdoc/>
        public MetroRadioButton BlueButton
            => BlueColor;

        /// <inheritdoc/>
        public MetroButton ApplyFilterButton
            => ApplyFilter;

        /// <inheritdoc/>
        public RgbColors GetSelectedColors(RgbColors color)
        {
            _command.Procedure(color.ToString());

            return (RgbColors)_command
                .Function(nameof(RgbViewAction.GetColor));
        }

        /// <inheritdoc/>
        public void Tooltip(string message)
           => ShowToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000
             );


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
    }
}
