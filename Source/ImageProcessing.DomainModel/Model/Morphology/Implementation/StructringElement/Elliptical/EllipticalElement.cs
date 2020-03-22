using System;

using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.DomainModel.Model.Morphology.Implementation.StructringElement.Elliptical
{
    internal sealed class EllipticalElement : IStructuringElement
    {
        public BitMatrix GetKernel((int width, int height) dimension)
        {
            var coVertex = dimension.height / 2;
            var focalDistance = dimension.width / 2;

            var unitsStartIndex = 0;
            var unitsEndIndex = 0;

            var kernel = new BitMatrix(dimension);

            for (var row = 0; row < dimension.height; ++row)
            {
                var dy = Math.Abs(row - coVertex);

                if (dy <= coVertex)
                {
                    var dx = focalDistance * Math.Sqrt(1 - dy * dy / (coVertex * coVertex));

                    unitsStartIndex = (int)Math.Max(focalDistance - dx, 0);
                    unitsEndIndex = (int)Math.Min(focalDistance + dx + 1, dimension.width);
                }

                for (int column = unitsStartIndex; column < unitsEndIndex; ++column)
                {
                    kernel[row, column] = true;
                }
            }

            return kernel;
        }
    }
}
