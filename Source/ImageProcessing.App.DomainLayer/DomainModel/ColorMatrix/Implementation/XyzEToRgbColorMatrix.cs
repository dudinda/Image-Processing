using System;

using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    /// <summary>
    /// XYZ of the E reference illuminant.
    /// </summary>
    internal sealed class XyzEToRgbColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
            = new ReadOnly2DArray<double>(
                new double[,] {
                    { 2.3706743,-0.9000405,-0.4706338, 0, 0 },
                    {-0.5138850, 1.4253036, 0.0885814, 0, 0 },
                    { 0.0052982,-0.0146949, 1.0093968, 0, 0 },
                    { 0.0000000, 0.0000000, 0.0000000, 1, 0 },
                    { 0.0000000, 0.0000000, 0.0000000, 0, 1 }
                });
    }
}
