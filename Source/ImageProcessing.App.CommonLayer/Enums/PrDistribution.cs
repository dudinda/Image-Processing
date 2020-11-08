using System.ComponentModel;
using ImageProcessing.App.CommonLayer.Attributes;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Specifies a probability distribution of a random variable.
    /// </summary>
    public enum PrDistribution
    {
        /// <summary>
        /// An unknown distribution.
        /// </summary>
        [Description("Select a distribution...")]
        Unknown     = 0,

        /// <summary>
        /// Exponential distribution.
        /// </summary>
        [Description("Exponential")]
        [Distribution("λ")]
        Exponential = 1,

        /// <summary>
        /// Rayleigh distribution.
        /// </summary>
        [Description("Rayleigh")]
        [Distribution("σ")]
        Rayleigh    = 2,

        /// <summary>
        /// Cauchy distribution.
        /// </summary>
        [Description("Cauchy")]
        [Distribution("x0", "γ")]
        Cauchy      = 3,

        /// <summary>
        /// Laplace distribution.
        /// </summary>
        [Description("Laplace")]
        [Distribution("μ", "b")]
        Laplace     = 4,

        /// <summary>
        /// Normal distribution.
        /// </summary>
        [Description("Normal")]
        [Distribution("μ", "σ")]
        Normal      = 5,

        /// <summary>
        /// Parabola distribution.
        /// </summary>
        [Description("Parabola")]
        [Distribution("k")]
        Parabola    = 6,

        /// <summary>
        /// Uniform distribution.
        /// </summary>
        [Description("Uniform")]
        [Distribution("a", "b")]
        Uniform     = 7,

        /// <summary>
        /// Weibull distribution.
        /// </summary>
        [Description("Weibull")]
        [Distribution("λ", "k")]
        Weibull     = 8
    }
}
