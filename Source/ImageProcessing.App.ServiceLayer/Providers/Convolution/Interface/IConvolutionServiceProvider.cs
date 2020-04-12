using System.Drawing;

using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution
{
    public interface IConvolutionServiceProvider
    {
        Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter);
    }
}
