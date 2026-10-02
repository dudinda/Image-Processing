using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Rotation.Implementation;
using ImageProcessing.App.Domain.Models.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Rotation;

namespace ImageProcessing.App.Domain.Factories.Rotation.Implementation
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
