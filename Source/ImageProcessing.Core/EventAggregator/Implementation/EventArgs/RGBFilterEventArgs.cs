using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class RGBFilterEventArgs : IBaseEventArgs<RGBFilter>
    {
        public RGBFilterEventArgs(RGBFilter arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="RGBFilter"/>
        public RGBFilter Arg { get; }

    }
}
