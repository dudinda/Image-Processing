using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class TransformHistogramEventArgs : BaseEventArgs
    {
        public TransformHistogramEventArgs(
            Distributions distribution,
            (string, string) parameters) : base()
        {
            Distribution = distribution;
            Parameters = parameters;
        }

        ///<inheritdoc cref="Distribution/>
        public Distributions Distribution { get; }

        /// <summary>
        /// Parameters of the specified <see cref="Distribution"/>.
        /// </summary>
        public (string, string) Parameters { get; }
    }
}
