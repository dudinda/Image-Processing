namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Filters based on a convolution matrix.
    /// </summary>
    public enum ConvolutionFilter
    {
        /// <summary>
        /// An unknown convolution filter
        /// </summary>
        Unknown                 = 0,

        /// <summary>
        /// The box blur filter with a kernel size 3x3.
        /// </summary>
        BoxBlur3x3              = 1,

        /// <summary>
        /// The box blur filter with a kernel size 5x5.
        /// </summary>
        BoxBlur5x5              = 2,

        /// <summary>
        /// The gaussian blur filter with a kernel size 3x3.
        /// </summary>
        GaussianBlur3x3         = 3,

        /// <summary>
        /// The gaussian blur filter with a kernel size 5x5.
        /// </summary>
        GaussianBlur5x5         = 4,

        /// <summary>
        /// The motion blur filter with a kernel size 9x9.
        /// </summary>
        MotionBlur9x9           = 5,

        /// <summary>
        /// The Gaussian operator with a kernel size 3x3.
        /// </summary>
        GaussianOperator3x3     = 6,

        /// <summary>
        /// The Gaussian operator with a kernel size 5x5
        /// </summary>
        GaussianOperator5x5     = 7,

        /// <summary>
        /// The Laplacian operator with a kernel size 3x3.
        /// </summary>
        LaplacianOperator3x3    = 8,

        /// <summary>
        /// The Laplacian operator with a kernel size 5x5.
        /// </summary>
        LaplacianOperator5x5    = 9,

        /// <summary>
        /// The Laplacian of Gaussian operator with a kernel size 3x3.
        /// </summary>
        LoGOperator             = 10,

        /// <summary>
        /// The horizontal Sobel operator, representing dG/dy where G is an image
        /// </summary>
        SobelOperatorHorizontal = 10,

        /// <summary>
        /// The vertical Sobel operator, representing dG/dx where G is an image
        /// </summary>
        SobelOperatorVertical   = 11,

        /// <summary>
        /// The Emboss operator with a kernel size 3x3.
        /// </summary>
        Emboss3x3               = 12,

        /// <summary>
        /// The Sharpen operator with a kernel size 3x3.
        /// </summary>
        Sharpen3x3              = 13,

        /// <summary>
        /// The Sobel operator with a kernel size 3x3
        /// </summary>
        SobelOperator3x3           = 14
    }
}
