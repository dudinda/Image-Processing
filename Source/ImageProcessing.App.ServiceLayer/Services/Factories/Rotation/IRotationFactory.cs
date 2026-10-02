using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Rotation;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Rotation
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
