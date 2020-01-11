namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Filters based on a convolution matrix.
    /// </summary>
    public enum ConvolutionFilter
    {
        /// <summary>
        /// The box blur filter with a kernel size 3x3.
        /// </summary>
        BoxBlur3x3 = 0,

        /// <summary>
        /// The box blur filter with a kernel size 5x5.
        /// </summary>
        BoxBlur5x5 = 1,

        /// <summary>
        /// The gaussian blur filter with a kernel size 3x3.
        /// </summary>
        GaussianBlur3x3 = 2,

        /// <summary>
        /// The gaussian blur filter with a kernel size 5x5.
        /// </summary>
        GaussianBlur5x5         = 3,

        /// <summary>
        /// The motion blur filter with a kernel size 9x9.
        /// </summary>
        MotionBlur9x9           = 4,

        /// <summary>
        /// The Gaussian operator with a kernel size 3x3.
        /// </summary>
        GaussianOperator3x3     = 5,

        /// <summary>
        /// The Gaussian operator with a kernel size 5x5
        /// </summary>
        GaussianOperator5x5     = 6,

        /// <summary>
        /// The Laplacian operator with a kernel size 3x3.
        /// </summary>
        LaplacianOperator3x3    = 7,

        /// <summary>
        /// The Laplacian operator with a kernel size 5x5.
        /// </summary>
        LaplacianOperator5x5    = 8,

        /// <summary>
        /// The Laplacian of Gaussian operator with a kernel size 3x3.
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
