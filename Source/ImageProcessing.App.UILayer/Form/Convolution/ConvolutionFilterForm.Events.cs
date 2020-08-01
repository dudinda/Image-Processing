using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;

namespace ImageProcessing.App.UILayer.Form.Convolution
{
    internal sealed partial class ConvolutionFilterForm
    {
        private void Bind()
        {
            Apply.Click += (sender, args)
                => Controller.Aggregator.PublishFrom(this,
                    new ConvolutionFilterEventArgs(this)
                );
        }
    }
}
