using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.Factory.RGBFiltersFactory;

namespace ImageProcessing.Core.Factory.Base
{
    public interface IBaseFactory
    {
        IDistributionFactory GetDistributionFactory();
        IConvolutionFilterFactory GetConvolutionFilterFactory();
        IRGBFiltersFactory GetRGBFilterFactory();
    }
}
