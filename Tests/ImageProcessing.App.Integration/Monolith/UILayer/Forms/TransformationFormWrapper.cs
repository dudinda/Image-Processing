using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers.Transformation;
using ImageProcessing.App.UILayer.Forms.Transformation;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class TransformationFormWrapper : ITransformationView, ITransformationFormExposer
    {
        private readonly TransformationForm _form;

        public TransformationFormWrapper(
            IMainView main,
            ITransformationFormEventBinderWrapper binder)
        {
            _form = new TransformationForm(main, binder);
        }

        public virtual AffTransform Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyButton
            => _form.ApplyButton;

        public virtual (string, string) Parameters
            => _form.Parameters;

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
