using System;
using System.Windows.Forms;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Forms.Rgb;
using ImageProcessing.App.UI.Services.FormExposers;

using MetroFramework.Controls;

namespace ImageProcessing.App.Presentation.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class RgbFormWrapper : IRgbFormExposer, IRgbView
    {
        private class NonUIRgbForm : RgbForm
        {
            public NonUIRgbForm(
                IMainView main,
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
            IMainView main,
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

        public virtual void EnableControls(bool isEnabled)
             => _form.EnableControls(isEnabled);
    }
}
