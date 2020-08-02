using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs
{
    public sealed class ConvolutionFilterEventArgs : BaseEventArgs
    {
        public ConvolutionFilterEventArgs(object publisher) : base(publisher)
        {

        }
    }
}
