using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    public sealed class GrayscaleRec709ColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0.2126, 0.7152, 0.0722, 0, 0 },
                    { 0.2126, 0.7152, 0.0722, 0, 0 },
                    { 0.2126, 0.7152, 0.0722, 0, 0 },
                    { 0.0000, 0.0000, 0.0000, 1, 0 },
                    { 0.0000, 0.0000, 0.0000, 0, 1 }
                });
    }
}
