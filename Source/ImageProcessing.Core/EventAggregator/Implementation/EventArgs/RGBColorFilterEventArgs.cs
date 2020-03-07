using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class RGBColorFilterEventArgs : IBaseEventArgs<RGBColors>
    {
        public RGBColorFilterEventArgs(RGBColors arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="RGBColors"/>
        public RGBColors Arg { get; }
    }
}
