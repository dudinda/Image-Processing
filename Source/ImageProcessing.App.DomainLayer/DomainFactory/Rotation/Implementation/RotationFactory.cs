using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Implementation
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
