using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.Distributions.OneParameterDistributions;
using ImageProcessing.Distributions.TwoParameterDistributions;

namespace ImageProcessing.Factory.Filters.Distributions
{
    /// <summary>
    /// Provides a factory method for all types
    /// implementing <see cref="IDistribution"/>.
    /// </summary>
    public class DistributionFactory : IDistributionFactory
    {
        /// <summary>
        /// A factory method
        /// where <see cref="Distribution"/> represents
        /// enumeration for types implementing <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution GetFilter(Distribution distribution) 
        {
            switch (distribution)
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

                default: throw new NotImplementedException(nameof(distribution));
            }
        }
    }
}
