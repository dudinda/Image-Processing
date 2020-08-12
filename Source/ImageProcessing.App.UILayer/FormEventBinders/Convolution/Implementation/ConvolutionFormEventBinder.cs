using System.Collections.Generic;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation
{
    internal sealed class ConvolutionFormEventBinder : IConvolutionFormEventBinder
    {
        private static readonly Dictionary<string, CommandAttribute>
               _cmdCommand = typeof(ConvolutionFormEventBinder).GetCommands();

        private readonly IEventAggregator _aggregator;

        public ConvolutionFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IConvolutionFormExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyConvolutionFilterEventArgs(source)
                );
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
