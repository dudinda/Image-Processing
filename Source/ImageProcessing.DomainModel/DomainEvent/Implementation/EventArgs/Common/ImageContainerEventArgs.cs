using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class ImageContainerEventArgs : IBaseEventArgs<ImageContainer>
    {
        public ImageContainerEventArgs(ImageContainer arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Arg { get; }
    }
}
