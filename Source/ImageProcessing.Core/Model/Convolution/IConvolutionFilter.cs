namespace ImageProcessing.Core.Model.Convolution
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
        /// Specifies the <see cref="Kernel"/> multiplication factor.
        /// </summary>
        double Factor { get; }

        /// <summary>
        /// Specifies the convolution matrix of a type implementing <see cref="IConvolutionFilter"/>.
        /// </summary>
        double[,] Kernel { get; }

        /// <summary>
        /// A value to be added to the final result value when calculating the matrix.
        /// </summary>
        double Bias { get; }
              
    }
}
