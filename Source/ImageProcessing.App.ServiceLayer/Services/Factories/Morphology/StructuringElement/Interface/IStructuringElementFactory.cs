using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.Factories.Morphology.StructuringElement.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IModelFactory<IStructuringElement, StructElem>
    {

    }
}
