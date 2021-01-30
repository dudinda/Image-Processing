using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IModelFactory<IStructuringElement, StructElem>
    {

    }
}
