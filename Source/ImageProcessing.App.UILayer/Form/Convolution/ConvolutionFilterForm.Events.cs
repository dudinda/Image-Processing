using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;

namespace ImageProcessing.App.UILayer.Form.Convolution
{
    partial class ConvolutionFilterForm
    {
        private void Bind()
        {
            Apply.Click += (sender, args)
                => Controller.Aggregator.Publish(
                    new ConvolutionFilterEventArgs()
                );
        }
    }
}
