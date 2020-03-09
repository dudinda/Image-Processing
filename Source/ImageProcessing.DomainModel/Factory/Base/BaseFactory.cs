using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.Factory.Morphology;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.DomainModel.Factory.Filters.Implementation.Morphology;
using ImageProcessing.Factory.Filters.Convolution;
using ImageProcessing.Factory.Filters.Distributions;
using ImageProcessing.Factory.Filters.RGBFilters;

namespace ImageProcessing.Factory.Base
{
    public class BaseFactory : IBaseFactory
    {
        public IConvolutionFilterFactory GetConvolutionFilterFactory()
            => new ConvolutionFilterFactory();
        
        public IDistributionFactory GetDistributionFactory()
            => new DistributionFactory();
        
        public IRGBFiltersFactory GetRGBFilterFactory()
            => new RGBFiltersFactory();

        public IMorphologyFactory GetMorphologyFactory()
            => new MorphologyFactory();
        
    }
}
