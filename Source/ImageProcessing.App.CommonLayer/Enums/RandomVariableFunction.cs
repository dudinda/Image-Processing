using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    public enum RandomVariableFunction
    {
        /// <summary>
        /// An unknown function.
        /// </summary>
        [Description("NaN")]
        Unknown = 0,

        /// <summary>
        /// p(x).
        /// </summary>
        [Description("p(x)")]
        PMF     = 1,

        /// <summary>
        /// F(x).
        /// </summary>
        [Description("F(x)")]
        CDF     = 2
    }
}
