using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Filters based on a convolution matrix.
    /// </summary>
    public enum ConvolutionFilter
    {
        /// <summary>
        /// An unknown convolution filter.
        /// </summary>
        [Description("Select a filter...")]
        Unknown                   = 0,

        /// <summary>
        /// The box blur filter with a kernel size 3x3.
        /// </summary>
        [Description("Box blur 3x3")]
        BoxBlur3x3                 = 1,

        /// <summary>
        /// The box blur filter with a kernel size 5x5.
        /// </summary>
        [Description("Box blur 5x5")]
        BoxBlur5x5                 = 2,

        /// <summary>
        /// The gaussian blur filter with a kernel size 3x3.
        /// </summary>
        [Description("Gaussian blur 3x3")]
        GaussianBlur3x3            = 3,

        /// <summary>
        /// The gaussian blur filter with a kernel size 5x5.
        /// </summary>
        [Description("Gaussian blur 5x5")]
        GaussianBlur5x5            = 4,

        /// <summary>
        /// The motion blur filter with a kernel size 9x9.
        /// </summary>
        [Description("Motion blur 9x9")]
        MotionBlur9x9              = 5,

        /// <summary>
        /// The Laplacian operator with a kernel size 3x3.
        /// </summary>
        [Description("Laplacian operator 3x3")]
        LaplacianOperator3x3       = 6,

        /// <summary>
        /// The Laplacian operator with a kernel size 5x5.
        /// </summary>
        [Description("Laplacian operator 5x5")]
        LaplacianOperator5x5       = 7,

        /// <summary>
        /// The horizontal Sobel operator, representing dG/dy where G is an image.
        /// </summary>
        [Description("Sobel horizontal operator 3x3")]
        SobelOperatorHorizontal3x3 = 8,

        /// <summary>
        /// The vertical Sobel operator, representing dG/dx where G is an image.
        /// </summary>
        [Description("Sobel vertical operator 3x3")]
        SobelOperatorVertical3x3   = 9,

        /// <summary>
        /// The Emboss operator with a kernel size 3x3.
        /// </summary>
        [Description("Emboss operator 3x3")]
        EmbossOperator3x3          = 10,

        /// <summary>
        /// The Sharpen operator with a kernel size 3x3.
        /// </summary>
        [Description("Sharpen operator 3x3")]
        SharpenOperator3x3         = 11,

        /// <summary>
        /// The Sobel operator with a kernel size 3x3.
        /// </summary>
        [Description("Sobel operator 3x3")]
        SobelOperator3x3           = 12,

        /// <summary>
        /// The Laplacian of Gaussian operator with a kernel size 3x3.
        /// </summary>
        [Description("Laplacian of Gaussian operator 3x3")]
        LoGOperator3x3             = 13,


    }
}
