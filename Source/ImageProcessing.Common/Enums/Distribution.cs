using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Distribution of a random variable.
    /// </summary>
    public enum Distribution
    {
        /// <summary>
        /// Unknown distribution
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Exponential distribution.
        /// </summary>
        [Description("1 - λ")]
        Exponential = 1,

        /// <summary>
        /// Rayleigh distribution.
        /// </summary>
        [Description("1 - σ")]
        Rayleigh    = 2,

        /// <summary>
        /// Cauchy distribution.
        /// </summary>
        [Description("1 - x0, 2 - γ")]
        Cauchy      = 3,

        /// <summary>
        /// Laplace distribution.
        /// </summary>
        [Description("1 - μ, 2 - b")]
        Laplace     = 4,

        /// <summary>
        /// Normal distribution.
        /// </summary>
        [Description("1 - μ, 2 - σ")]
        Normal      = 5,

        /// <summary>
        /// Parabola distribution.
        /// </summary>
        [Description("1 - k")]
        Parabola    = 6,

        /// <summary>
        /// Uniform distribution.
        /// </summary>
        [Description("1 - a, 2 - b")]
        Uniform     = 7,

        /// <summary>
        /// Weibull distribution.
        /// </summary>
        [Description("1 - λ, 2 - k")]
        Weibull     = 8
    }
}
