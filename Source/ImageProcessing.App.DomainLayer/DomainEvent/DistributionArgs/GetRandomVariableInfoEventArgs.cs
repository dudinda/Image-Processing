using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class GetRandomVariableInfoEventArgs : BaseEventArgs
    {
        public GetRandomVariableInfoEventArgs(
            RandomVariableInfo action,
            ImageContainer container)  : base()
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
