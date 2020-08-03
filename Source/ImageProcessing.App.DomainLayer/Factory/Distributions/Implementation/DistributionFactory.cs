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
        /// where the <see cref="CommonLayer.Enums.Distributions"/> represents an
        /// enumeration for the types implementing the <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution Get(CommonLayer.Enums.Distributions distribution)
            => distribution
        switch
        {
            CommonLayer.Enums.Distributions.Exponential
                => new ExponentialDistribution(),
            CommonLayer.Enums.Distributions.Laplace
                => new LaplaceDistribution(),
            CommonLayer.Enums.Distributions.Rayleigh
                => new RayleighDistribution(),
            CommonLayer.Enums.Distributions.Cauchy
                => new CauchyDistribution(),
            CommonLayer.Enums.Distributions.Normal
                => new NormalDistribution(),
            CommonLayer.Enums.Distributions.Parabola
                => new ParabolaDistribution(),
            CommonLayer.Enums.Distributions.Uniform
                => new UniformDistribution(),
            CommonLayer.Enums.Distributions.Weibull
                => new WeibullDistribution(),

            _   => throw new NotImplementedException(nameof(distribution))
        };              
    }
}
