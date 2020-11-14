using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface
{
    public interface IColorMatrix
    {
        ReadOnly2DArray<double> Matrix { get; }
    }
}
