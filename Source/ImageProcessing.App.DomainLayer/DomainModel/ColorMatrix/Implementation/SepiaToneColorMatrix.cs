using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    public sealed class SepiaToneColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0.393, 0.769, 0.189, 0, 0 },
                    { 0.349, 0.686, 0.168, 0, 0 },
                    { 0.272, 0.534, 0.131, 0, 0 },
                    { 0.000, 0.000, 0.000, 1, 0 },
                    { 0.000, 0.000, 0.000, 0, 1 }
                });
    }
}
