using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class DistributionEventArgs : IBaseEventArgs<Distribution>
    {
        public DistributionEventArgs(Distribution arg, (string, string) parameters)
        {
            Arg = arg;
            Parameters = parameters;
        }

        ///<inheritdoc cref="Distribution/>
        public Distribution Arg { get; }
        public (string, string) Parameters { get; private set; }
    }
}
