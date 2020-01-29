using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class RandomVariableEventArgs : ImageContainerEventArgs
    {
        public RandomVariableEventArgs(RandomVariable action, ImageContainer container) : base(container)
        {
            Action = action;
        }

        public RandomVariable Action { get; }
    }
}
