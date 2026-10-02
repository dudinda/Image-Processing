using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Distribution.Implementation.OneParameter;
using ImageProcessing.App.ServiceLayer.Models.Distribution.Implementation.TwoParameter;
using ImageProcessing.App.ServiceLayer.Models.Distribution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Distribution;

namespace ImageProcessing.App.ServiceLayer.Factories.Distribution.Implementation
{
    /// <inheritdoc cref="IDistributionFactory" />
    public sealed class DistributionFactory : IDistributionFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="PrDistribution"/> represents an
        /// enumeration for the types implementing the <see cref="IDistribution"/>.
        /// </summary>
        public IDistribution Get(PrDistribution distribution)
            => distribution
        switch
        {
            PrDistribution.Exponential
                => new ExponentialDistribution(),
            PrDistribution.Laplace
                => new LaplaceDistribution(),
            PrDistribution.Rayleigh
                => new RayleighDistribution(),
            PrDistribution.Cauchy
                => new CauchyDistribution(),
            PrDistribution.Normal
                => new NormalDistribution(),
            PrDistribution.Parabola
                => new ParabolaDistribution(),
            PrDistribution.Uniform
                => new UniformDistribution(),
            PrDistribution .Weibull
                => new WeibullDistribution(),

            _   => throw new NotImplementedException(nameof(distribution))
        };              
    }
}
