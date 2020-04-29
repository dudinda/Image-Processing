using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class DistributionEventArgs : BaseEventArgs
    {
        public DistributionEventArgs(Distribution distribution, (string, string) parameters)
        {
            Distribution = distribution;
            Parameters = parameters;
        }

        ///<inheritdoc cref="Distribution/>
        public Distribution Distribution { get; }

        /// <summary>
        /// Parameters of the specified <see cref="Distribution"/>.
        /// </summary>
        public (string, string) Parameters { get; }
    }
}
