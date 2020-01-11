namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Filters based on a convolution matrix
    /// </summary>
    public enum ConvolutionFilter
    {
        /// <summary>
        /// Box blur filter with the kernel size 3x3
        /// </summary>
        BoxBlur3x3              = 0,

        /// <summary>
        /// Box blur filter with the kernel size 5x5
        /// </summary>
        BoxBlur5x5              = 1,

        /// <summary>
        /// Gaussian blur filter with the kernel size 3x3
        /// </summary>
        GaussianBlur3x3         = 2,

        /// <summary>
        /// Gaussian blur filter with the kernel size 5x5
        /// </summary>
        GaussianBlur5x5         = 3,

        /// <summary>
        /// Motion blur filter with the kernel size 9x9
        /// </summary>
        MotionBlur9x9           = 4,

        /// <summary>
        /// Gaussian operator with the kernel size 3x3
        /// </summary>
        GaussianOperator3x3     = 5,

        /// <summary>
        /// Gaussian operator with the kernel size 5x5
        /// </summary>
        GaussianOperator5x5     = 6,

        /// <summary>
        /// Laplacian operator with the kernel size 3x3
        /// </summary>
        LaplacianOperator3x3    = 7,

        /// <summary>
        /// Laplacian operator with the kernel size 5x5
        /// </summary>
        LaplacianOperator5x5    = 8,

        /// <summary>
        /// Laplacian of gaussian operator with the kernel size 3x3
        /// </summary>
        LoGOperator             = 9,

        /// <summary>
        /// 
        /// </summary>
        SobelOperatorHorizontal = 10,
        SobelOperatorVertical   = 11,
        Emboss3x3               = 12,
        Sharpen3x3              = 13
    }
}
