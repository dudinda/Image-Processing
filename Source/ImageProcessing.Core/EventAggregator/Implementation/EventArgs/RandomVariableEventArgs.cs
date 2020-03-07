using ImageProcessing.Common.Enums;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class RandomVariableEventArgs : ImageContainerEventArgs
    {
        public RandomVariableEventArgs(RandomVariable action, ImageContainer container) : base(container)
        {
            Action = action;
        }

        ///<inheritdoc cref="RandomVariable"/>
        public RandomVariable Action { get; }
    }
}
