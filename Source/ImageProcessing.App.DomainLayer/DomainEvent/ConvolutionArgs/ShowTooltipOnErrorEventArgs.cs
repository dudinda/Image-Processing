using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs
{
    public sealed class ShowTooltipOnErrorEventArgs : BaseEventArgs
    {
        public ShowTooltipOnErrorEventArgs(string error)
            => Error = error;

        public string Error { get; }
    }
}
