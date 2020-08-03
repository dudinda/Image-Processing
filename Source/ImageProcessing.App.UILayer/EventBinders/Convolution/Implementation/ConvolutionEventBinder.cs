using System.Collections.Generic;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.UILayer.EventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormElements.Convolution;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.EventBinders.Convolution.Implementation
{
    internal sealed class ConvolutionEventBinder : IConvolutionEventBinder
    {
        private static readonly Dictionary<string, CommandAttribute>
               _cmdCommand = typeof(ConvolutionEventBinder).GetCommands();

        private readonly IEventAggregator _aggregator;

        public ConvolutionEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void Bind(IConvolutionElementExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyConvolutionFilterEventArgs(source)
                );
        }

        public bool ProcessCmdKey(IConvolutionElementExposer view, Keys keyData)
        {
            var key = keyData.ToString();

            if(_cmdCommand.ContainsKey(key))
            {
                return (bool)_cmdCommand[key].Method.Invoke(
                    this, new object[] { view });
            }

            return false;
        }


        [Command(nameof(Keys.Q))]
        private bool ClickCommandQ(IConvolutionElementExposer source)
        {
            _aggregator.PublishFrom(source,
                new ApplyConvolutionFilterEventArgs(source)
            );

            return true;
        }

        [Command(nameof(Keys.Enter))]
        private bool ClickCommandEnter(IConvolutionElementExposer source)
        {
            _aggregator.PublishFrom(source,
                new ApplyConvolutionFilterEventArgs(source)
            );

            return true;
        }
    }
}
