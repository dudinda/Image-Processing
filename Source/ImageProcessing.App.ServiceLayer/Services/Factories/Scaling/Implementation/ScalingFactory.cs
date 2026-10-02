using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.Factories.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Models.Scaling;

namespace ImageProcessing.App.DomainLayer.Factories.Scaling.Implementation
{
    public sealed class ScalingFactory : IScalingFactory
    {
        public IScaling Get(ScalingMethod scaling)
            => scaling
        switch
        {
            ScalingMethod.Bicubic
                => new BicubicInterpolation(),
            ScalingMethod.Bilinear
                => new BilinearInterpolation(),
            ScalingMethod.Proximal
                => new ProximalInterpolation(),

            _   => throw new NotImplementedException(nameof(scaling))
        };
    }
}
