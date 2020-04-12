using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.DistributionArgs
{
    public sealed class RandomVariableEventArgs 
    {
        public RandomVariableEventArgs(RandomVariable action, ImageContainer container) 
        {
            Action    = action;
            Container = container;
        }

        /// <inheritdoc cref="RandomVariable"/>
        public RandomVariable Action { get; }

        /// <inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
