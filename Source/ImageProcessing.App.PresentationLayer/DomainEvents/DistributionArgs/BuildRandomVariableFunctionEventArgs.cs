using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs
{
    /// <summary>
    /// Build a plot of a random variable function.
    /// </summary>
    public class BuildRandomVariableFunctionEventArgs : BaseEventArgs
    {
        public BuildRandomVariableFunctionEventArgs(
            RndFunction action, ImageContainer container) : base()
        {
            Action = action;
            Container = container;
        }

        /// <inheritdoc cref="RndFunction"/>
        public RndFunction Action { get; }

        /// <inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
