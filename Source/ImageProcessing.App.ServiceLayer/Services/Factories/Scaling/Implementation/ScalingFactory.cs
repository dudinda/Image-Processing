using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Scaling.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Scaling;
using ImageProcessing.App.ServiceLayer.Services.Factories.Scaling;

namespace ImageProcessing.App.ServiceLayer.Factories.Scaling.Implementation
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
