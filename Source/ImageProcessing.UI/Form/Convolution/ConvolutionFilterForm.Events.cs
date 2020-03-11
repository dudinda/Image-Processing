using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;

namespace ImageProcessing.UI.Form.Convolution
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
