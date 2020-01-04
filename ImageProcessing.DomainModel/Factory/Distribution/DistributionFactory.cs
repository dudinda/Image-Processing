﻿using ImageProcessing.Common.Enum;
using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Distributions.OneParameterDistributions;
using ImageProcessing.Factory.Abstract;

using System;

namespace ImageProcessing.Factory
{
    public class DistributionFactory : IDistributionFactory
    {
        public IDistribution GetDistribution(Distribution distribution, (int, int) parms) 
        {
            switch (distribution)
            {
                case Distribution.Exponential:
                    return new ExponentialDistribution(parms.Item1);
                case Distribution.Rayleigh:
                    return new RayleighDistribution(parms.Item1);
            }

            throw new ArgumentException();
        }
    }
}
