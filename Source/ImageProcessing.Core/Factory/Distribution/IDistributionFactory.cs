using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Core.Factory.DistributionFactory
{
    public interface IDistributionFactory : IFilterFactory<IDistribution, Distribution>
    {

    }
}
