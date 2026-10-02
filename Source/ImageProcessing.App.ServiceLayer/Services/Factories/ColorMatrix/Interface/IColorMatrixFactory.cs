using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.ColorMatrix.Interface;

namespace ImageProcessing.App.DomainLayer.Factories.ColorMatrix.Interface
{
    public interface IColorMatrixFactory : IModelFactory<IColorMatrix, ClrMatrix>
    {

    }
}
