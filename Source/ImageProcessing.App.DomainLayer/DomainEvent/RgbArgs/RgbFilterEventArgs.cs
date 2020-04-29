using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    public sealed class RgbFilterEventArgs : BaseEventArgs
    {
        public RgbFilterEventArgs(RgbFilter filter)
            => Filter = filter;

        ///<inheritdoc cref="RgbFilter"/>
        public RgbFilter Filter { get; }

    }
}
