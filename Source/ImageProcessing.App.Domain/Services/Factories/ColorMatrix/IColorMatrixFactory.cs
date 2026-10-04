using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.ColorMatrix;

namespace ImageProcessing.App.Domain.Services.Factories.ColorMatrix
{
    public interface IColorMatrixFactory : IModelFactory<IColorMatrix, ClrMatrix>
    {

    }
}
