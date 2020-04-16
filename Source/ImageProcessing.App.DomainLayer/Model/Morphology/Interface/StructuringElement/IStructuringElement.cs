using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Interface.StructuringElement
{
    /// <summary>
    /// Specifies a structuring element of a
    /// morphological operator.
    /// </summary>
    public interface IStructuringElement
    {
        /// <summary>
        /// Get the kernel with the specified dimension.
        /// </summary>
        /// <param name="dimension">width x height</param>
        /// <returns>The <see cref="BitMatrix"/> as a kernel.</returns>
        BitMatrix GetKernel((int width, int height) dimension);
    }
}
