using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.TupleExtensions;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class DistributionEventArgs : IBaseEventArgs<Distribution>
    {
        public DistributionEventArgs(Distribution arg, (string, string) parameters)
        {
            Arg = arg;

            if(parameters.TryParse<decimal, decimal>(out var parms))
            {
                Parameters = parms;
            }
        }

        ///<inheritdoc cref="Distribution/>
        public Distribution Arg { get; }
        public (decimal, decimal) Parameters { get; private set; }
    }
}
