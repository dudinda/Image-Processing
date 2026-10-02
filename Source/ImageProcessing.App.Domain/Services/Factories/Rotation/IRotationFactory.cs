using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Rotation;

namespace ImageProcessing.App.Domain.Services.Factories.Rotation
{
    public interface IRotationFactory : IModelFactory<IRotation, RotationMethod>
    {

    }
}
