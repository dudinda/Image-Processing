using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class TransformHistogramEventArgs : BaseEventArgs
    {
        public TransformHistogramEventArgs(
            object publisher,
            (string, string) parameters) : base(publisher)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Parameters of the specified <see cref="Distribution"/>.
        /// </summary>
        public (string, string) Parameters { get; }
    }
}
