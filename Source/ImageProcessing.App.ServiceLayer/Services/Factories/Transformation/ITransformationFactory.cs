using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Transformation;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Transformation
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
