using ImageProcessing.App.DomainModel.DomainEvent.ConvolutionArgs;

namespace ImageProcessing.App.UILayer.Form.Convolution
{
    partial class ConvolutionFilterForm
    {
        private void Bind()
        {
            Apply.Click += (sender, args)
                => EventAggregator.Publish(new ConvolutionFilterEventArgs());
        }
    }
}
