using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.DomainEvent.RgbArgs
{
    public sealed class RgbFilterEventArgs 
    {
        public RgbFilterEventArgs(RgbFilter filter)
            => Filter = filter;

        ///<inheritdoc cref="RgbFilter"/>
        public RgbFilter Filter { get; }

    }
}
