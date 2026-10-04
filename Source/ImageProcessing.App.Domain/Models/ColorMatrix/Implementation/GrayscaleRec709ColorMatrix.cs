using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.ColorMatrix.Implementation
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
