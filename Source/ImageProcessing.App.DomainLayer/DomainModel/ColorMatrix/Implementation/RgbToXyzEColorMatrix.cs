using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    /// <summary>
    /// XYZ of the E reference illuminant.
    /// </summary>
    internal sealed class RgbToXyzEColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0.4887180, 0.3106803, 0.2006017, 0, 0 },
                    { 0.1762044, 0.8129847, 0.0108109, 0, 0 },
                    { 0.0000000, 0.0102048, 0.9897952, 0, 0 },
                    { 0.0000000, 0.0000000, 0.0000000, 1, 0 },
                    { 0.0000000, 0.0000000, 0.0000000, 0, 1 }
                });
    }
}
