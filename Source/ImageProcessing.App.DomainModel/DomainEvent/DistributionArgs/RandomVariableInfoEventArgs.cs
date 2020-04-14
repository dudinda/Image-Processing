using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.DistributionArgs
{
    public sealed class RandomVariableInfoEventArgs 
    {
        public RandomVariableInfoEventArgs(
            RandomVariableInfo action,
            ImageContainer container) 
        {
            Action = action;
            Container = container;
        }

        /// <inheritdoc cref="RandomVariableInfo"/>
        public RandomVariableInfo Action { get; }

        /// <inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
