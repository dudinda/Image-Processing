using ImageProcessing.Common.Enum;
using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.Factory.Abstract
{
    public interface IConvolutionFilterFactory
    {
        AbstractConvolutionFilter GetConvolutionFilter(ConvolutionFilter filter);
    }
}
