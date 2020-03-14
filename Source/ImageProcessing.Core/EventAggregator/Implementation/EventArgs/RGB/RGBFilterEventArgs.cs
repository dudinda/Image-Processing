using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class RgbFilterEventArgs : IBaseEventArgs<RgbFilter>
    {
        public RgbFilterEventArgs(RgbFilter arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="RgbFilter"/>
        public RgbFilter Arg { get; }

    }
}
