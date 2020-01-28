using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

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
