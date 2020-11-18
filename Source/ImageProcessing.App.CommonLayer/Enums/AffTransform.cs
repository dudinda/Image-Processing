using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    public enum AffTransform
    {
        /// <summary>
        /// An unknown affine transformation.
        /// </summary>
        [Description("Select a transformation...")]
        Unknown          = 0,

        /// <summary>
        /// Translation transformation.
        /// </summary>
        [Description("Translation transformation")]
        Translation       = 1,

        /// <summary>
        /// Cyclic translation transformation.
        /// </summary>
        [Description("Cyclic translation transformation")]
        CyclicTranslation = 2,

        /// <summary>
        /// Scale transformation.
        /// </summary>
        [Description("Scale transformation")]
        Scale             = 3,

        /// <summary>
        /// Shear transformation.
        /// </summary>
        [Description("Shear transformation")]
        Shear             = 4
    }
}
