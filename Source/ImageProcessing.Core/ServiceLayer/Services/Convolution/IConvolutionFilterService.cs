using System.Drawing;

using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, IConvolutionFilter filter);
    }
}
