using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.DistributionArgs
{
    public sealed class DistributionEventArgs
    {
        public DistributionEventArgs(Distribution distribution, (string, string) parameters)
        {
            Distribution = distribution;
            Parameters   = parameters;
        }

        ///<inheritdoc cref="Distribution/>
        public Distribution Distribution { get; }

        /// <summary>
        /// Parameters of the specified <see cref="Distribution"/>.
        /// </summary>
        public (string, string) Parameters { get; }
    }
}
