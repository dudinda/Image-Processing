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

        public virtual double Radians
            => _form.Radians;

        public virtual RotationMethod Dropdown
            => _form.Dropdown;

        public virtual MetroButton RotateButton
            => _form.RotateButton;

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

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
