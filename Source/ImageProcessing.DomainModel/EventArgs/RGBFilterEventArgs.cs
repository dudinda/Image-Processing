using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class RGBFilterEventArgs : IBaseEventArgs<RGBFilter>
    {
        public RGBFilterEventArgs(RGBFilter arg)
        {
            Arg = arg;
        }

        /// <summary>
        /// <see cref="RGBFilter"/>
        /// </summary>
        public RGBFilter Arg { get; }

    }
}
