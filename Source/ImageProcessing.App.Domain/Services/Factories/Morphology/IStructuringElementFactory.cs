using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Morphology;

namespace ImageProcessing.App.Domain.Services.Factories.Morphology
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IModelFactory<IStructuringElement, StructElem>
    {

    }
}
