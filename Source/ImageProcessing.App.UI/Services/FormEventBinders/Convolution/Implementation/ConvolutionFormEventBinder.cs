using System.Windows.Forms;

using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.UI.Services.FormEventBinders.Convolution;
using ImageProcessing.App.UI.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Services.Aggregator;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Convolution.Implementation
{
    internal sealed class ConvolutionFormEventBinder : IConvolutionFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public ConvolutionFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IConvolutionFormExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ApplyConvolutionKernelEventArgs());

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
        }

        public bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Q:

                    view.ApplyButton.PerformClick();
                    return true;

                case Keys.Enter:

                    view.ApplyButton.PerformClick();
                    return true;                
            }

            return false;
        }
    }
}
