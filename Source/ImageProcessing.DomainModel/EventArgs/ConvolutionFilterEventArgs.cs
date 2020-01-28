using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ConvolutionFilterEventArgs : IBaseEventArgs<ConvolutionFilter>
    {
        public ConvolutionFilterEventArgs(ConvolutionFilter arg)
        {
            Arg = arg;
        }
        public ConvolutionFilter Arg { get; }
    }
}
