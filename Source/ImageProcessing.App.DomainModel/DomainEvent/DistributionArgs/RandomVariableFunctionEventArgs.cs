using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.DistributionArgs
{
    public class RandomVariableFunctionEventArgs
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
