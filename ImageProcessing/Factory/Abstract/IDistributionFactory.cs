using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Factory.Abstract
{
    public interface IDistributionFactory
    {
        IDistribution GetDistribution(Distribution distribution, (int first, int second));
    }
}
