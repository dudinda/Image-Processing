using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormExposers.Rgb;
using ImageProcessing.App.UILayer.Forms.Rgb;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class RgbFormWrapper : IRgbFormExposer, IRgbViewWrapper
    {
        private class NonUIRgbForm : RgbForm
        {
            public NonUIRgbForm(
                IMainViewWrapper main,
                IRgbFormEventBinderWrapper wrapper) : base(main, wrapper)
            {
               
            }

            protected override void Write(Action action)
              => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();
        }

        private readonly NonUIRgbForm _form;

        public RgbFormWrapper(
            IMainViewWrapper main,
            IRgbFormEventBinderWrapper wrapper)
        {
            _form = new NonUIRgbForm(main, wrapper);
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

        public virtual event FormClosedEventHandler FormClosed
        {
            add
            {
                _form.FormClosed += value;
            }
            remove
            {
                _form.FormClosed -= value;
            }
        }

        public virtual void Close()
            => _form.Close();

        public virtual void Dispose()
            => _form.Dispose();

        public bool Focus()
            => _form.Focus();
        
        public virtual RgbChannels GetSelectedChannels()
            => _form.GetSelectedChannels();

        public virtual void Show()
        {

        }


        public virtual void Tooltip(string message)
            => _form.Tooltip(message);

        public void EnableFormControls(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void EnableControls(bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
