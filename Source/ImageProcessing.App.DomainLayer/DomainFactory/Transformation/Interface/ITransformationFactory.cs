using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface
{
    public interface ITransformationFactory : IModelFactory<ITransformation, AffTransform>
    {

    }
}
