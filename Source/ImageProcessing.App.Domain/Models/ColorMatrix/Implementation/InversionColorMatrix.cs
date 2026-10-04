using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.Domain.Models.ColorMatrix.Implementation
{
    public sealed class InversionColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    {-1, 0, 0, 0, 1 },
                    { 0,-1, 0, 0, 1 },
                    { 0, 0,-1, 0, 1 },
                    { 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1 }
                });
    }
}
