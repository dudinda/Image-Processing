using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Providers.Interface.Convolution
{
    public interface IConvolutionServiceProvider
    {
        Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter);
    }
}
