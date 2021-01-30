using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
