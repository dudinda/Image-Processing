using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.App.DomainModel.DomainEvent.ConvolutionArgs
{
    public sealed class ShowTooltipOnErrorEventArgs
    {
        public ShowTooltipOnErrorEventArgs(string error)
            => Error = error;

        public string Error { get; }
    }
}
