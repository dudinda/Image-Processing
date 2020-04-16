using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.RgbArgs
{
    public sealed class RgbFilterEventArgs 
    {
        public RgbFilterEventArgs(RgbFilter filter)
            => Filter = filter;

        ///<inheritdoc cref="RgbFilter"/>
        public RgbFilter Filter { get; }

    }
}
