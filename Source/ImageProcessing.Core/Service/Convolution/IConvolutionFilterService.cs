using System.Drawing;

using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.Services.ConvolutionFilterServices.Interface
{
    public interface IConvolutionFilterService
    {
        Image Convolution(Bitmap source, AbstractConvolutionFilter filter);
    }
}
