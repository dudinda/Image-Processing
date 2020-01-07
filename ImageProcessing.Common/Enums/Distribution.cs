using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    public enum Distribution
    {
        [Description("1 - λ")]
        Exponential = 0,

        [Description("1 - σ")]
        Rayleigh    = 1,

        [Description("1 - x0, 2 - γ")]
        Cauchy      = 2,

        [Description("1 - μ, 2 - b")]
        Laplace     = 3,

        [Description("1 - μ, 2 - σ")]
        Normal      = 4,

        [Description("1 - k")]
        Parabola    = 5,

        [Description("1 - a, 2 - b")]
        Uniform     = 6,

        [Description("1 - λ, 2 - k")]
        Weibull     = 7
    }
}
