using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    internal sealed class YiqToRgbColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
           = new ReadOnly2DArray<double>(
               new double[,] {
                    { 1, 0.956, 0.623, 0, 0 },
                    { 1,-0.272,-0.648, 0, 0 },
                    { 1,-1.105, 1.705, 0, 0 },
                    { 0, 0.000, 0.000, 1, 0 },
                    { 0, 0.000, 0.000, 0, 1 }
               });
    }
}
