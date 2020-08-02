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

        public void Bind(IConvolutionElementsExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ConvolutionFilterEventArgs(source)
                );
        }

        public bool ProcessCmdKey(IConvolutionElementsExposer view, Keys keyData)
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
        private bool ClickCommandQ(IConvolutionElementsExposer source)
        {
            _aggregator.PublishFrom(source,
                new ConvolutionFilterEventArgs(source)
            );

            return true;
        }

        [Command(nameof(Keys.Enter))]
        private bool ClickCommandEnter(IConvolutionElementsExposer source)
        {
            _aggregator.PublishFrom(source,
                new ConvolutionFilterEventArgs(source)
            );

            return true;
        }
    }
}
