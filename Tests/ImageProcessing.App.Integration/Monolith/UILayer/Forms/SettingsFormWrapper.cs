using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposers.Settings;
using ImageProcessing.App.UILayer.Forms.Settings;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class SettingsFormWrapper : ISettingsViewWrapper, ISettingsFormExposer
    {
        private class NonUISettingsForm : SettingsForm
        {
            public NonUISettingsForm(
                IMainViewWrapper main,
                ISettingsFormEventBinderWrapper binder) : base(main, binder)
            {

            }

            protected override void Write(Action action)
                => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();

        }

        private readonly NonUISettingsForm _form;

        public SettingsFormWrapper(
            IMainViewWrapper main,
            ISettingsFormEventBinderWrapper binder)
        {
            _form = new NonUISettingsForm(main, binder);
        }

        public virtual RotationMethod FirstDropdown
            => _form.FirstDropdown;

        public virtual ScalingMethod SecondDropdown
            => _form.SecondDropdown;

        public virtual Luma ThirdDropdown
            => _form.ThirdDropdown;

        public virtual MetroComboBox LumaDropDown
            => _form.LumaDropDown;

        public virtual MetroComboBox ScalingDropDown
            => _form.ScalingDropDown;

        public virtual MetroComboBox RotationDropDown
            => _form.RotationDropDown;

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

        public virtual bool Focus()
            => _form.Focus();
     
        public virtual void Show()
        {
            
        }

        public void EnableControls(bool isEnabled)
        {
            throw new NotImplementedException();
        }
    }
}
