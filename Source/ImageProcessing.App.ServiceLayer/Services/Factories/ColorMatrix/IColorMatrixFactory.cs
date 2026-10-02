using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.ColorMatrix.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.ColorMatrix
{
    public interface IColorMatrixFactory : IModelFactory<IColorMatrix, ClrMatrix>
    {

    }
}
