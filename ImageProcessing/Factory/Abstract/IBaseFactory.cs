using ImageProcessing.ConvulationFilters;
using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Enum;
using ImageProcessing.RGBFilter.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Factory.Abstract
{
    public interface IBaseFactory
    {
        IDistribution GetDistribution(Distribution distribution);
        AbstractConvolutionFilter GetConvolutionFilter(ConvolutionFilter filter);
        IRGBFilter GetFilter();
    }
}
