using System.Drawing;

using ImageProcessing.DomainModel.Convolution.Interface;

namespace ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, IConvolutionFilter filter);
    }
}
