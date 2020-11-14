using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface
{
    public interface IColorMatrixFactory : IModelFactory<IColorMatrix, ClrMatrix>
    {

    }
}
