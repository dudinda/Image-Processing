using System.ComponentModel;

namespace ImageProcessing.App.Common.Enums
{
    /// <summary>
    /// Specifies information about a random variable.
    /// </summary>
    public enum RandomVariableInfo
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
        Entropy                = 4,

        /// <summary>
        /// E(X | Y).
        /// </summary>
        [Description("E(X | Y)")]
        ConditionalExpectation = 5,

        /// <summary>
        /// Var(X | Y).
        /// </summary
        [Description("Var(X | Y)")]
        ConditionalVariance    = 6
    }
}
