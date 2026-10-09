using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Scaling;
using ImageProcessing.App.Domain.Models.Scaling.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Scaling;

namespace ImageProcessing.App.Domain.Factories.Scaling.Implementation
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
