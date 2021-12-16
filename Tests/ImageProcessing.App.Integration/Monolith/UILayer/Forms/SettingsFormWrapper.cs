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

        public RotationMethod FirstDropdown => throw new NotImplementedException();

        public ScalingMethod SecondDropdown => throw new NotImplementedException();

        public Luma ThirdDropdown => throw new NotImplementedException();

        public MetroComboBox LumaDropDown => throw new NotImplementedException();

        public MetroComboBox ScalingDropDown => throw new NotImplementedException();

        public MetroComboBox RotationDropDown => throw new NotImplementedException();

        public event FormClosedEventHandler FormClosed;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
