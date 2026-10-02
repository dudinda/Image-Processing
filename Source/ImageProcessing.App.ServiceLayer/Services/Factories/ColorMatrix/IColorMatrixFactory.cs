using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.ColorMatrix.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.ColorMatrix
{
    public interface IColorMatrixFactory : IModelFactory<IColorMatrix, ClrMatrix>
    {

    }
}
