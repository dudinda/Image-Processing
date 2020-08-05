using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ShowTooltipOnErrorEventArgs : BaseEventArgs
    {
        public ShowTooltipOnErrorEventArgs(string error) : base()
            => Error = error;

        public string Error { get; }
    }
}
