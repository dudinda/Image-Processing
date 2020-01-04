using ImageProcessing.ConvulationFilters;

using System.Drawing;

namespace ImageProcessing.DomainModel.Services.ConvolutionFilter
{
    public interface IConvolutionFilterService
    {
        Bitmap Convolution(Bitmap source, AbstractConvolutionFilter filter);
    }
}
