using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ConvolutionFilterEventArgs : IBaseEventArgs<ConvolutionFilter>
    {
        public ConvolutionFilterEventArgs(ConvolutionFilter arg)
        {
            Arg = arg;
        }

        /// <summary>
        /// <see cref="ConvolutionFilter"/>
        /// </summary>
        public ConvolutionFilter Arg { get; }
    }
}
