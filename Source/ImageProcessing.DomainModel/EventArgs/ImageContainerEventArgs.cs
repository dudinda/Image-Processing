using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ImageContainerEventArgs : IBaseEventArgs<ImageContainer>
    {
        public ImageContainerEventArgs(ImageContainer arg)
        {
            Arg = arg;
        }

        public ImageContainer Arg { get; }
    }
}
