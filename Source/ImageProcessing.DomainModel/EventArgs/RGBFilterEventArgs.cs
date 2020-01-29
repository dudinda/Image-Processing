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

        public RGBFilter Arg { get; }

    }
}
