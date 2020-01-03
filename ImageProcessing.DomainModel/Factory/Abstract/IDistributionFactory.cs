using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Enum;

namespace ImageProcessing.Factory.Abstract
{
    public interface IDistributionFactory
    {
        IDistribution GetDistribution(Distribution distribution, (int, int ) parms );
    }
}
