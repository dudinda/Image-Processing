namespace ImageProcessing.Common.Enum
{
    public enum ConvolutionFilter
    {
        BoxBlur3x3              = 0,
        BoxBlur5x5              = 1,
        GaussianBlur3x3         = 2,
        GaussianBlur5x5         = 3,
        MotionBlur9x9           = 4,
        GaussianOperator3x3     = 5,
        GaussianOperator5x5     = 6,
        LaplacianOperator3x3    = 7,
        LaplacianOperator5x5    = 8,
        SobelOperatorHorizontal = 9,
        SobelOperatorVertical   = 10,
        Emboss3x3               = 11,
        Sharpen3x3              = 12
    }
}
