using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Distributions.OneParameterDistributions;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.DomainModel.Factory.Filters.Interface;
using ImageProcessing.Distributions.TwoParameterDistributions;

namespace ImageProcessing.Factory.Filters.Distributions
{
    public class DistributionFactory : IDistributionFactory
    {
        public IDistribution GetFilter(string distribution) 
        {
            switch (distribution.GetEnumValueByName<Distribution>())
            {
                case Distribution.Exponential:
                    return new ExponentialDistribution();
                case Distribution.Rayleigh:
                    return new RayleighDistribution();
                case Distribution.Laplace:
                    return new LaplaceDistribution();
                case Distribution.Cauchy:
                    return new CauchyDistribution();
                case Distribution.Normal:
                    return new NormalDistribution();
                case Distribution.Parabola:
                    return new ParabolaDistribution();
                case Distribution.Uniform:
                    return new UniformDistribution();
                case Distribution.Weibull:
                    return new WeibullDistribution();
            }

            throw new ArgumentException();
        }
    }
}
