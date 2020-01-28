using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class RGBColorFilterEventArgs : BaseEventArgs<RGBColors>
    {
        public RGBColorFilterEventArgs(RGBColors arg)
        {
            Arg = arg;
        }

        public RGBColors Arg { get; }
    }
}
