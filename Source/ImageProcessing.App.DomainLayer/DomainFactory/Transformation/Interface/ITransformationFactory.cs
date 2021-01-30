using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
