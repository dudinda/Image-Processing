using ImageProcessing.ConvolutionFilters.Blur.BoxBlur;
using ImageProcessing.ConvolutionFilters.Blur.MotionBlur;
using ImageProcessing.ConvolutionFilters.EdgeDetection;
using ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator;
using ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator;
using ImageProcessing.ConvolutionFilters.Emboss;
using ImageProcessing.ConvolutionFilters.GaussianBlur3x3;
using ImageProcessing.ConvolutionFilters.GaussianBlur5x5;
using ImageProcessing.ConvolutionFilters.Sharpen;
using ImageProcessing.ConvulationFilters;
using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Distributions.OneParameterDistributions;
using ImageProcessing.Distributions.TwoParameterDistributions;
using ImageProcessing.Enum;
using ImageProcessing.Factory.Abstract;
using ImageProcessing.RGBFilter.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Factory
{
    public class BaseFactory : IBaseFactory
    {
        public IConvolutionFilterFactory GetConvolutionFilterFactory()
        {
            return new ConvolutionFilterFactory();
        }

        public IDistributionFactory GetDistributionFactory()
        {
            return new DistributionFactory();
        }

        public IRGBFilter GetFilter()
        {
            throw new NotImplementedException();
        }
    }
}
