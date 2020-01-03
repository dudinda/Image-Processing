using System.ComponentModel;

namespace ImageProcessing.Common.Enum
{
    public enum Distribution
    {
        [Description("1 - λ")]
        Exponential = 0,

        [Description("1 - σ")]
        Rayleigh    = 1,

        [Description("")]
        Cauchy      = 2,

        [Description("")]
        Laplace     = 3,

        [Description("")]
        Normal      = 4,

        [Description("")]
        Parabola    = 5,

        [Description("")]
        Uniform     = 6,

        [Description("")]
        Weibull     = 7
    }
}
