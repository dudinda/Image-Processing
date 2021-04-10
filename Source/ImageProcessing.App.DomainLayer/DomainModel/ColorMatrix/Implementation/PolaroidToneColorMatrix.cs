using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    public sealed class PolaroidToneColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 1.438,-0.122,-0.016, 0,-0.03 },
                    {-0.062, 1.378,-0.016, 0, 0.05 },
                    {-0.062,-0.122, 1.483, 0,-0.02 },
                    { 0.000, 0.000, 0.000, 1, 0.00 },
                    { 0.000, 0.000, 0.000, 0, 1.00 }
                });
    }
}
