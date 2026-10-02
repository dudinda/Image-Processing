using ImageProcessing.App.Domain.Models.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.Domain.Models.ColorMatrix.Implementation
{
    public sealed class UnknownColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 }
                });
    }
}
