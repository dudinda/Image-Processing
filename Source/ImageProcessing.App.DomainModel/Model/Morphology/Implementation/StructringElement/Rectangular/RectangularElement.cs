using ImageProcessing.App.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.StructringElement.Rectangular
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
