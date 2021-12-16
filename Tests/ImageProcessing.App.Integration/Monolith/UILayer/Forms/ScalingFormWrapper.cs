using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.Forms.Scaling;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class ScalingFormWrapper : IScalingView, IScalingFormExposer
    {
        private readonly ScalingForm _form;

        public ScalingFormWrapper(
            IMainView main,
            IScalingFormEventBinderWrapper binder)
        {
            _form = new ScalingForm(main, binder);
        }

        public virtual (string, string) Parameters
            => _form.Parameters;

        public virtual ScalingMethod Dropdown
            => _form.Dropdown;

        public virtual MetroButton ScaleButton
            => _form.ScaleButton;

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
        
        public virtual bool Focus()
            => _form.Focus();
       
        public virtual void Show()
        {
            
        }

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
