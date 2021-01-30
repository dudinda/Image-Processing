using System.ComponentModel;

namespace ImageProcessing.App.DomainLayer.Code.Enums
{
    /// <summary>
    /// Specifies a morphology operator.
    /// </summary>
    public enum MorphOperator
    {
        /// <summary>
        /// An unknown operation.
        [Description("Select an operator...")]
        Unknown     = 0,

        /// <summary>
        /// Erosion operator.
        /// </summary>
        [Description("Erosion")]
        Erosion     = 1,

        /// <summary>
        /// Dilation operator.
        /// </summary>
        [Description("Dilation")]
        Dilation    = 2,

        /// <summary>
        /// Opening operator.
        /// </summary>
        [Description("Opening")]
        Opening     = 3,

        /// <summary>
        /// Closing operator.
        /// </summary>
        [Description("Closing")]
        Closing     = 4,

        /// <summary>
        /// Addition operator.
        /// </summary>
        [Description("Addition")]
        Addition    = 5,

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        [Description("Subtraction")]
        Subtraction = 6,

        /// <summary>
        /// Morphological Gradient operator.
        /// </summary>
        [Description("Morphological Gradient")]
        Gradient     = 7,

        /// <summary>
        /// Top Hat operator.
        /// </summary>
        [Description("Top Hat")]
        TopHat       = 8,

        /// <summary>
        /// Black Hat operator.
        /// </summary>
        [Description("Black Hat")]
        BlackHat     = 9
    }
}
