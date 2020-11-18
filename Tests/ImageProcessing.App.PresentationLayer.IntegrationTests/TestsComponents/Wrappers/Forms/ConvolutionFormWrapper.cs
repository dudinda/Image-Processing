using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.UILayer.Form.Convolution;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class ConvolutionFormWrapper : IConvolutionFormExposer, IConvolutionView
    {
        private readonly IAutoResetEventService _synchronizer;
        private readonly ConvolutionForm _form;
        public ConvolutionFormWrapper(
          IAutoResetEventService synchronzer,
          IAppController controller,
          IConvolutionFormEventBinder binder) 
        {
            _synchronizer = synchronzer;
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
            => _synchronizer.Signal();

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);   
    }
}
