using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs
{
    /// <summary>
    /// Get a random variable characteristic from the specified container.
    /// </summary>
    public sealed class GetRandomVariableInfoEventArgs : BaseEventArgs
    {
        public GetRandomVariableInfoEventArgs(
            RndInfo action, ImageContainer container)  : base()
        {
            Action = action;
            Container = container;
        }

        /// <inheritdoc cref="RndInfo"/>
        public RndInfo Action { get; }

        /// <inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
