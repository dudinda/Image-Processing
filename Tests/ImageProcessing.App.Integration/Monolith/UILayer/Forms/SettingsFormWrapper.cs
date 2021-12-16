using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers.Settings;
using ImageProcessing.App.UILayer.Forms.Settings;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class SettingsFormWrapper : ISettingsView, ISettingsFormExposer
    {
        private readonly SettingsForm _form;

        public SettingsFormWrapper(
            IMainView main,
            ISettingsFormEventBinderWrapper binder)
        {
            _form = new SettingsForm(main, binder);
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
    }
}
