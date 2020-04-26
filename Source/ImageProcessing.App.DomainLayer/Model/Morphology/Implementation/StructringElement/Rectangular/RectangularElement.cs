using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.StructuringElement;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.StructringElement.Rectangular
{
    /// <summary>
    /// Implements the <see cref="IStructuringElement"/>.
    /// </summary>
    internal sealed class RectangularElement : IStructuringElement
    {
        /// <inheritdoc cref="IStructuringElement"/>.
        public BitMatrix GetKernel((int width, int height) dimension)
        {
            var kernel = new BitMatrix(dimension);

            for (var row = 0; row < dimension.height; ++row)
            {
                for (var column = 0; column < dimension.width; ++column)
                {
                    kernel[row, column] = true;
                }
            }

            return kernel;
        }
    }
}
