using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class RandomVariableInfoEventArgs : BaseEventArgs
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
