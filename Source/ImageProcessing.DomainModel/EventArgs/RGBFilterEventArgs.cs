using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class RGBFilterEventArgs : BaseEventArgs<RGBFilter>
    {
        public RGBFilterEventArgs(RGBFilter arg)
        {
            Arg = arg;
        }

        public RGBFilter Arg { get; }

    }
}
