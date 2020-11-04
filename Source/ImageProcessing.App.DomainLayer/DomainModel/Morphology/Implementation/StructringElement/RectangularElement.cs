using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.StructringElement
{
    /// <summary>
    /// Implements the <see cref="IStructuringElement"/>.
    /// </summary>
    internal sealed class RectangularElement : IStructuringElement
    {
        /// <inheritdoc cref="IStructuringElement"/>.
        public BitMatrix GetKernel((int width, int height) dimension)
        {
            var kernel = new BitMatrix(dimension.width, dimension.height);

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
