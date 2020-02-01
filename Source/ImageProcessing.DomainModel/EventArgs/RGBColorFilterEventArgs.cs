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

        /// <summary>
        /// <see cref="RGBColors"/>
        /// </summary>
        public RGBColors Arg { get; }
    }
}
