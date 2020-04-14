using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.StructuringElement;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainModel.Factory.Morphology.Interface.StructuringElement
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IModelFactory<IStructuringElement, StructuringElem>
    {

    }
}
