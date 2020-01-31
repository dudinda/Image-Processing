using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ZoomEventArgs : IBaseEventArgs<ImageContainer>
    {
        public ZoomEventArgs(ImageContainer arg)
        {
            Arg = arg;
        }

        public ImageContainer Arg { get; }
    }
}
