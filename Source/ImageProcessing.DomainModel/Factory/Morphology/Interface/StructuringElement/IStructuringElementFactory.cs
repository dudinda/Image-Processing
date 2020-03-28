using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Base;
using ImageProcessing.DomainModel.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.DomainModel.Factory.Morphology.Interface.StructuringElement
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IBaseFactory<IStructuringElement, StructuringElem>
    {

    }
}
