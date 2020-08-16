using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.UILayer.Form.Convolution;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms
{
    internal class ConvolutionFormWrapper : IConvolutionFormExposer
    {
        private readonly IManualResetEventService _synchronizer;
        private readonly ConvolutionForm _form;
        public ConvolutionFormWrapper(
          IManualResetEventService synchronzer,
          IAppController controller,
          IConvolutionFormEventBinder binder) 
        {
            _synchronizer = synchronzer;
            _form = new ConvolutionForm(controller, binder);
        }

        public virtual ConvolutionFilter Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyButton
            => _form.ApplyButton;

        public virtual void Close()
            => _form.Close();
       
        public virtual void Dispose()
            => _form.Dispose();
    
        public virtual void Show()
            => _synchronizer.Event.Set();

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);   
    }
}
