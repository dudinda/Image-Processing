using System;
using System.Linq;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.EventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormControls.Rgb;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Rgb
{
    internal sealed partial class RgbForm : BaseForm, IRgbElementExposer
    {
        public RgbForm(
            IAppController controller,
            IRgbEventBinder binder) : base(controller)
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

            binder.Bind(this);
        }

        /// <inheritdoc/>
        public RgbFilter SelectedFilter
        {
            get => RgbFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RgbFilter>();
        }

        public MetroRadioButton RedButton
            => RedColor;

        public MetroRadioButton GreenButton
            => RedColor;

        public MetroRadioButton BlueButton
            => BlueColor;

        public MetroButton ApplyFilterButton
            => ApplyFilter;

        /// <inheritdoc/>
        public RgbColors GetSelectedColors(RgbColors color)
        {
            _command[
                 color.ToString()
            ].Method.Invoke(this, null);

            return (RgbColors)_command[
                 nameof(RgbViewAction.GetColor)
            ].Method.Invoke(this, null);
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
    }
}
