using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.Factories.Rotation.Interface
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
