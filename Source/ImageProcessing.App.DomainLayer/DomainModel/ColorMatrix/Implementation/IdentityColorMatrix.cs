using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    internal sealed class IdentityColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
          = new ReadOnly2DArray<double>(
                new double[,] {
                    { 1, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0 },
                    { 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1 }
                });

    }
}
