using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution
{
    public interface IConvolutionServiceProvider
    {
        Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter);
    }
}
