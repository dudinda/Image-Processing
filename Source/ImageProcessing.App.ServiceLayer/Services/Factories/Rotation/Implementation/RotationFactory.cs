using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Rotation.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Rotation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rotation;

namespace ImageProcessing.App.DomainLayer.Factories.Rotation.Implementation
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
