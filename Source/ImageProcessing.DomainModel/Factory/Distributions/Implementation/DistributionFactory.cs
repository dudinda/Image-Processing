using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Distributions.Interface;
using ImageProcessing.DomainModel.Model.Distributions.Implementation.OneParameter;
using ImageProcessing.DomainModel.Model.Distributions.Implementation.TwoParameter;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.DomainModel.Factory.Distributions.Implementation
{
    /// <inheritdoc cref="IDistributionFactory" />
    public sealed class DistributionFactory : IDistributionFactory
    {
        /// <summary>
        /// A factory method
        /// where <see cref="Distribution"/> represents an
        /// enumeration for the types implementing the <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution Get(Distribution distribution)
        => distribution switch
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
