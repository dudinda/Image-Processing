using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Interface;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.TwoParameter;
using ImageProcessing.App.DomainLayer.Model.Distributions.Interface;

namespace ImageProcessing.App.DomainLayer.Factory.Distributions.Implementation
{
    /// <inheritdoc cref="IDistributionFactory" />
    public sealed class DistributionFactory : IDistributionFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="Distribution"/> represents an
        /// enumeration for the types implementing the <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution Get(Distribution distribution)
            => distribution
        switch
        {
            Distribution.Exponential
                => new ExponentialDistribution(),
            Distribution.Laplace
                => new LaplaceDistribution(),
            Distribution.Rayleigh
                => new RayleighDistribution(),
            Distribution.Cauchy
                => new CauchyDistribution(),
            Distribution.Normal
                => new NormalDistribution(),
            Distribution.Parabola
                => new ParabolaDistribution(),
            Distribution.Uniform
                => new UniformDistribution(),
            Distribution.Weibull
                => new WeibullDistribution(),

            _   => throw new NotImplementedException(nameof(distribution))
        };              
    }
}
