using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.App.UILayer.Forms.Convolution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class ConvolutionFormWrapper : IConvolutionFormExposer, IConvolutionView
    {
        private readonly ConvolutionForm _form;
        public ConvolutionFormWrapper(
          IAppController controller,
          IConvolutionFormEventBinder binder) 
        {
            _form = new ConvolutionForm(controller, binder);
        }

        public virtual ConvKernel Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyButton
            => _form.ApplyButton;

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
