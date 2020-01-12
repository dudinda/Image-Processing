using System.Drawing;

using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.Services.ConvolutionFilterServices.Interface
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, AbstractConvolutionFilter filter);
    }
}
