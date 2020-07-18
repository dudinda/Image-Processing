using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.DomainLayer.Convolution.Interface
{
    /// <summary>
    /// Specifies a convolution filter.
    /// </summary>
    public interface IConvolutionFilter
    {
        /// <summary>
        /// Specifies the name of a filter.
        /// </summary>
        string FilterName { get; }

        /// <summary>
        /// Specifies a <see cref="Kernel"/> multiplication factor.
        /// </summary>
        double Factor { get; }

        /// <summary>
        /// Specifies a convolution matrix of the type implementing the <see cref="IConvolutionFilter"/>.
        /// </summary>
        ReadOnly2DArray<double> Kernel { get; }

        /// <summary>
        /// A value to be added to the final result value when calculating the matrix.
        /// </summary>
        double Bias { get; }            
    }
}
