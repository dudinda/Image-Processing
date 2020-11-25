using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
