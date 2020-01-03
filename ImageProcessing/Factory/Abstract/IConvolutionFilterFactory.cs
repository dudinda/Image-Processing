using ImageProcessing.ConvulationFilters;
using ImageProcessing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Factory.Abstract
{
    public interface IConvolutionFilterFactory
    {
        AbstractConvolutionFilter GetConvolutionFilter(ConvolutionFilter filter);
    }
}
