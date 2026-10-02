using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Rotation.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Rotation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rotation;

namespace ImageProcessing.App.ServiceLayer.Factories.Rotation.Implementation
{
    public sealed class RotationFactory : IRotationFactory
    {
        public IRotation Get(RotationMethod rotation)
            => rotation
        switch
         {
             RotationMethod.AreaMapping
                 => new AreaMappingRotation(),
             RotationMethod.Shear
                 => new ShearRotation(),
             RotationMethod.Sampling
                 => new SamplingRotation(),

             _   => throw new NotImplementedException(nameof(rotation))
         };
    }
}
