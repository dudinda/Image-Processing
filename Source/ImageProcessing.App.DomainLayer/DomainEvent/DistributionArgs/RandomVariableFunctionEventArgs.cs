using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public class RandomVariableFunctionEventArgs : BaseEventArgs
    {
        public RandomVariableFunctionEventArgs(
            RandomVariableFunction action,
            ImageContainer container)
        {
            Action = action;
            Container = container;
        }

        /// <inheritdoc cref="RandomVariableFunction"/>
        public RandomVariableFunction Action { get; }

        /// <inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
