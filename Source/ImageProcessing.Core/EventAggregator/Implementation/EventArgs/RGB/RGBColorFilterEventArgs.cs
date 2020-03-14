using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class RgbColorFilterEventArgs : IBaseEventArgs<RgbColors>
    {
        public RgbColorFilterEventArgs(RgbColors arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Arg { get; }
    }
}
