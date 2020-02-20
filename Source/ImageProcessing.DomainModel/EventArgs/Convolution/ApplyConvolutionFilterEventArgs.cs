using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;
using ImageProcessing.Core.Pipeline.Block.Implementation;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ApplyConvolutionFilterEventArgs : IBaseEventArgs<PipelineBlock<Bitmap>>
    {
        public ApplyConvolutionFilterEventArgs(PipelineBlock<Bitmap> arg)
        {
            Arg = arg;
        }

        /// <summary>
        /// <see cref="ConvolutionFilter"/>
        /// </summary>
        public PipelineBlock<Bitmap> Arg { get; }
    }
}
