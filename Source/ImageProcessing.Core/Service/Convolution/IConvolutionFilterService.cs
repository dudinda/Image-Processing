using System.Drawing;

using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.Services.ConvolutionFilterServices.Interface
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, IConvolutionFilter filter);
    }
}
