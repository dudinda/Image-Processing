using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormExposers.Rgb;
using ImageProcessing.App.UILayer.Forms.Rgb;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class RgbFormWrapper : IRgbFormExposer, IRgbView
    {
        private readonly RgbForm _form;

        public RgbFormWrapper(
            IAppController controller,
            IRgbFormEventBinder binder)
        {
            _form = new RgbForm(controller, binder);
        }

        public virtual RgbFltr Dropdown
            => _form.Dropdown;

        public virtual MetroCheckBox RedButton
            => _form.RedButton;

        public virtual MetroCheckBox GreenButton
            => _form.GreenButton;

        public virtual MetroCheckBox BlueButton
            => _form.BlueButton;

        public virtual MetroButton ApplyFilterButton
            => _form.ApplyFilterButton;

        public virtual MetroButton ColorMatrixMenuButton
            => _form.ColorMatrixMenuButton;

        public virtual void Close()
            => _form.Close();

        public virtual void Dispose()
            => _form.Dispose();

        public bool Focus()
            => _form.Focus();
        
        public virtual RgbChannels GetSelectedChannels(RgbChannels color)
            => _form.GetSelectedChannels(color);

        public virtual void Show()
        {

        }


        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
