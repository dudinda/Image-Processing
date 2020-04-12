using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.Model;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.StructuringElement;

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
