using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.Form.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class RgbFormWrapper : IRgbFormExposer
    {
        private readonly IManualResetEventService _synchronizer;
        private readonly RgbForm _form;
        public RgbFormWrapper(
            IManualResetEventService synchronizer,
            IAppController controller,
            IRgbFormEventBinder binder,
            IRgbFormCommand command)
        {
            _synchronizer = synchronizer;
            _form = new RgbForm(controller, binder, command);
        }

        public virtual RgbFilter Dropdown
            => _form.Dropdown;

        public virtual MetroCheckBox RedButton
            => _form.RedButton;

        public virtual MetroCheckBox GreenButton
            => _form.GreenButton;

        public virtual MetroCheckBox BlueButton
            => _form.BlueButton;

        public virtual MetroButton ApplyFilterButton
            => _form.ApplyFilterButton;

        public virtual void Close()
            => _form.Close();

        public virtual void Dispose()
            => _form.Dispose();

        public virtual RgbColors GetSelectedColors(RgbColors color)
            => _form.GetSelectedColors(color);

        public virtual void Show()
        {
            _synchronizer.Event.Set();
        }
           

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
