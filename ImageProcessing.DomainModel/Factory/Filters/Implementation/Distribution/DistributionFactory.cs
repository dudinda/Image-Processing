using ImageProcessing.Common.Enums;
using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Distributions.OneParameterDistributions;
using ImageProcessing.Factory.Abstract;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.DomainModel.Factory.Filters.Interface;

using System;

namespace ImageProcessing.Factory
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
            }

            throw new ArgumentException();
        }
    }
}
