using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.App.UILayer.Forms.Convolution;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class ConvolutionFormWrapper : IConvolutionFormExposer, IConvolutionView
    {
        private readonly ConvolutionForm _form;

        public ConvolutionFormWrapper(
          IMainView main,
          IConvolutionFormEventBinderWrapper wrapper) 
        {
            _form = new ConvolutionForm(main, wrapper);
        }

        public virtual ConvKernel Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyButton
            => _form.ApplyButton;

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
       
        public virtual void Show()
        {

        }
        public virtual void Tooltip(string message)
            => _form.Tooltip(message);   
    }
}
