using System;
using System.Windows.Forms;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Forms.Transformation;
using ImageProcessing.App.UI.Services.FormExposers;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UI.Forms
{
    internal class TransformationFormWrapper : ITransformationView, ITransformationFormExposer
    {
        private class NonUITransformationForm : TransformationForm
        {
            public NonUITransformationForm(
                IMainView main,
                ITransformationFormEventBinderWrapper binder) : base(main, binder)
            {

            }

            protected override void Write(Action action)
                => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();

        }

        private readonly NonUITransformationForm _form;

        public TransformationFormWrapper(
            IMainView main,
            ITransformationFormEventBinderWrapper binder)
        {
            _form = new NonUITransformationForm(main, binder);
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

        public virtual void EnableControls(bool isEnabled)
            => _form.EnableControls(isEnabled);
    }
}
