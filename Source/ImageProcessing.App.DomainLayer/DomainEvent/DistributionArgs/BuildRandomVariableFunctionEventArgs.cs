using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public class BuildRandomVariableFunctionEventArgs : BaseEventArgs
    {
        public BuildRandomVariableFunctionEventArgs(
            RandomVariableFunction action,
            ImageContainer container) : base()
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