using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.Factories.Transformation.Interface
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
