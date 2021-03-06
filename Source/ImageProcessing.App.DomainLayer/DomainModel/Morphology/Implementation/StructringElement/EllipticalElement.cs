using System;

using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.StructringElement
{
    /// <summary>
    /// Implements the <see cref="IStructuringElement"/>.
    /// </summary>
    internal sealed class EllipticalElement : IStructuringElement
    {
        /// <inheritdoc cref="IStructuringElement"/>.
        public BitMatrix GetKernel((int width, int height) dimension)
        {
            var coVertex = dimension.height / 2;
            var focalDistance = dimension.width / 2;

            var unitsStartIndex = 0;
            var unitsEndIndex = 0;

            var kernel = new BitMatrix(dimension.width, dimension.height);

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
