using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.ColorMatrix.Implementation
{
    public sealed class GrayscaleRec601ColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0.299, 0.587, 0.114, 0, 0 },
                    { 0.299, 0.587, 0.114, 0, 0 },
                    { 0.299, 0.587, 0.114, 0, 0 },
                    { 0.000, 0.000, 0.000, 1, 0 },
                    { 0.000, 0.000, 0.000, 0, 1 }
                });
    }
}
