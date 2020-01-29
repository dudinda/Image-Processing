using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class RGBColorFilterEventArgs : IBaseEventArgs<RGBColors>
    {
        public RGBColorFilterEventArgs(RGBColors arg)
        {
            Arg = arg;
        }

        public RGBColors Arg { get; }
    }
}
