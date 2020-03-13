using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Core.ServiceLayer.Providers.Convolution
{
    public interface IConvolutionFilterServiceProvider
    {
        Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter);
    }
}
