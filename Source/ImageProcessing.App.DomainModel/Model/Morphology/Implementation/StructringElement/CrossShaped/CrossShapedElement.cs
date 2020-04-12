using ImageProcessing.App.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.StructringElement.CrossShaped
{
    /// <summary>
    /// Implements the <see cref="IStructuringElement"/>.
    /// </summary>
    internal sealed class CrossShapedElement : IStructuringElement
    {
        /// <inheritdoc cref="IStructuringElement"/>.
        public BitMatrix GetKernel((int width, int height) dimension)
        {
            var kernel = new BitMatrix(dimension);

            var x = dimension.width / 2;
            var y = dimension.height / 2;

            for (var row = 0; row < dimension.height; ++row)
            {
                for (var column = 0; column < dimension.width; ++column)
                {
                    if (row == y)
                    {
                        kernel[row, column] = true;
                    }
                    else
                    {
                        if (column == x)
                        {
                            kernel[row, column] = true;
                        }
                    }
                }
            }

            return kernel;
        }
    }
}
