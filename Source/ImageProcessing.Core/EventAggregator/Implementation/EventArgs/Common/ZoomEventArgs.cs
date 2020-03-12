using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class ZoomEventArgs : IBaseEventArgs<ImageContainer>
    {
        public ZoomEventArgs(ImageContainer arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Arg { get; }
    }
}
