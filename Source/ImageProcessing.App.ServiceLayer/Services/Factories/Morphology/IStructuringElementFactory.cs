using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Morphology
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IStructuringElement"/>.
    /// </summary>
    public interface IStructuringElementFactory : IModelFactory<IStructuringElement, StructElem>
    {

    }
}
