using System.Drawing;

using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.Services.ConvolutionFilter
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, AbstractConvolutionFilter filter);
    }
}
