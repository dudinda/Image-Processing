using System;
using System.Collections.Generic;
using System.Text;

using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation
{
    internal sealed class GrayscaleRec601ColorMatrix : IColorMatrix
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
