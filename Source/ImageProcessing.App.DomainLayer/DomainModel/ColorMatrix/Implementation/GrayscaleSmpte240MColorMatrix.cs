using System;

using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    internal sealed class GrayscaleSmpte240MColorMatrix : IColorMatrix
    {
        public ReadOnly2DArray<double> Matrix { get; }
          = new ReadOnly2DArray<double>(
                new double[,] {
                    { 0.212, 0.701, 0.087, 0, 0 },
                    { 0.212, 0.701, 0.087, 0, 0 },
                    { 0.212, 0.701, 0.087, 0, 0 },
                    { 0.000, 0.000, 0.000, 1, 0 },
                    { 0.000, 0.000, 0.000, 0, 1 }
                });
    }
}
