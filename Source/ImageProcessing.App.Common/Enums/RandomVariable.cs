using System.ComponentModel;

namespace ImageProcessing.App.Common.Enums
{
    /// <summary>
    /// Specifies characteristics of a random variable.
    /// </summary>
    public enum RandomVariable
    {
        /// <summary>
        /// An unknown characteristic.
        /// </summary>
        [Description("NaN")]
        Unknown                = 0,

        /// <summary>
        /// E[X].
        /// </summary>
        [Description("E[X]")]
        Expectation            = 1,

        /// <summary>
        /// Var[X].
        /// </summary>
        [Description("Var[X]")]
        Variance               = 2,

        /// <summary>
        /// σ.
        /// </summary>
        [Description("σ")]
        StandardDeviation      = 3,

        /// <summary>
        /// H(x).
        /// </summary>
        [Description("H(x)")]
        Entropy                = 5,

        /// <summary>
        /// E(X | Y).
        /// </summary>
        [Description("E(X | Y)")]
        ConditionalExpectation = 6,

        /// <summary>
        /// Var(X | Y).
        /// </summary
        [Description("Var(X | Y)")]
        ConditionalVariance    = 7,

        /// <summary>
        /// p(x).
        /// </summary>
        [Description("p(x)")]
        PMF                    = 8,

        /// <summary>
        /// F(x).
        /// </summary>
        [Description("F(x)")]
        CDF                    = 9
    }
}
