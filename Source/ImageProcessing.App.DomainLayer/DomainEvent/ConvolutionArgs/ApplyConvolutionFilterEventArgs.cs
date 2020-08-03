using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs
{
    public sealed class ApplyConvolutionFilterEventArgs : BaseEventArgs
    {
        public ApplyConvolutionFilterEventArgs(object publisher) : base(publisher)
        {

        }
    }
}
