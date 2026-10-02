using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Models.ColorMatrix.Interface
{
    public interface IColorMatrix
    {
        ReadOnly2DArray<double> Matrix { get; }
    }
}
