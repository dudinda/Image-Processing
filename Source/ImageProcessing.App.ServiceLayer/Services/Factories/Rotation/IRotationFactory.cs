using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Rotation;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Rotation
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
