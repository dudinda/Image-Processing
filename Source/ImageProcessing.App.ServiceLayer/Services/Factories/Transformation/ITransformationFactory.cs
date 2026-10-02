using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Transformation;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Transformation
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
