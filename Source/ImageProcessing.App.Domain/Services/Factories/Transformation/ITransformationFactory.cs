using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Transformation;

namespace ImageProcessing.App.Domain.Services.Factories.Transformation
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
