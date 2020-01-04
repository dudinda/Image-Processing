using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Factory.Abstract
{
    public interface IDistributionFactory
    {
        IDistribution GetDistribution(Common.Enum.Distribution distribution, (int, int ) parms );
    }
}
