using System;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.TwoParameter;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;

namespace ImageProcessing.App.DomainLayer.Factory.Distribution.Implementation
{
    /// <inheritdoc cref="IDistributionFactory" />
    internal sealed class DistributionFactory : IDistributionFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="CommonLayer.Enums.Distributions"/> represents an
        /// enumeration for the types implementing the <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution Get(CommonLayer.Enums.Distributions distribution)
            => distribution
        switch
        {
            Distributions.Exponential
                => new ExponentialDistribution(),
            Distributions.Laplace
                => new LaplaceDistribution(),
            Distributions.Rayleigh
                => new RayleighDistribution(),
            Distributions.Cauchy
                => new CauchyDistribution(),
            Distributions.Normal
                => new NormalDistribution(),
            Distributions.Parabola
                => new ParabolaDistribution(),
            Distributions.Uniform
                => new UniformDistribution(),
            Distributions.Weibull
                => new WeibullDistribution(),

            _   => throw new NotImplementedException(nameof(distribution))
        };              
    }
}
