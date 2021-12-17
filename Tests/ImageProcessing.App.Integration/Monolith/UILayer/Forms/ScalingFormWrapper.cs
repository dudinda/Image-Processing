using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.Forms.Scaling;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class ScalingFormWrapper : IScalingViewWrapper, IScalingFormExposer
    {
        private class NonUIScalingForm : ScalingForm
        {
            public NonUIScalingForm(
                IMainViewWrapper main,
                IScalingFormEventBinderWrapper binder) : base(main, binder)
            {

            }

            protected override void Write(Action action)
                => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();

        }

        private readonly NonUIScalingForm _form;

        public ScalingFormWrapper(
            IMainViewWrapper main,
            IScalingFormEventBinderWrapper binder)
        {
            _form = new NonUIScalingForm(main, binder);
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
