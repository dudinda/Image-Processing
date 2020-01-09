using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Distribution of a random variable
    /// </summary>
    public enum Distribution
    {
        /// <summary>
        /// Exponential distribution
        /// </summary>
        [Description("1 - λ")]
        Exponential = 0,

        /// <summary>
        /// Rayleigh distribution
        /// </summary>
        [Description("1 - σ")]
        Rayleigh    = 1,

        /// <summary>
        /// Cauchy distribution
        /// </summary>
        [Description("1 - x0, 2 - γ")]
        Cauchy      = 2,

        /// <summary>
        /// Laplace distribution
        /// </summary>
        [Description("1 - μ, 2 - b")]
        Laplace     = 3,

        /// <summary>
        /// Normal distribution
        /// </summary>
        [Description("1 - μ, 2 - σ")]
        Normal      = 4,

        /// <summary>
        /// Parabola distribution
        /// </summary>
        [Description("1 - k")]
        Parabola    = 5,

        /// <summary>
        /// Uniform distribution
        /// </summary>
        [Description("1 - a, 2 - b")]
        Uniform     = 6,

        /// <summary>
        /// Weibull distribution
        /// </summary>
        [Description("1 - λ, 2 - k")]
        Weibull     = 7
    }
}
