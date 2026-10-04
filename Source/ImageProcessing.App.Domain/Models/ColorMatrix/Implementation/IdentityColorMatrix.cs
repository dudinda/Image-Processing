using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.ColorMatrix.Implementation
{
    public sealed class IdentityColorMatrix : IColorMatrix
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
