using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.Forms.Rotation;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class RotationFormWrapper : IRotationView, IRotationFormExposer
    {
        private readonly RotationForm _form;

        public RotationFormWrapper(
            IMainView main,
            IRotationFormEventBinderWrapper binder)
        {
            _form = new RotationForm(main, binder);
        }

        public double Radians => throw new System.NotImplementedException();

        public RotationMethod Dropdown => throw new System.NotImplementedException();

        public MetroButton RotateButton => throw new System.NotImplementedException();

        public event FormClosedEventHandler FormClosed;

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool Focus()
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Tooltip(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
