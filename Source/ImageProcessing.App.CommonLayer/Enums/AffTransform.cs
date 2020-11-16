using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    public enum AffTransform
    {
        /// <summary>
        /// An unknown affine transformation.
        /// </summary>
        [Description("Select a transformation...")]
        Unknown     = 0,

        /// <summary>
        /// Translation transformation.
        /// </summary>
        [Description("Translation transformation")]
        Translation = 1,

        /// <summary>
        /// Scale transformation.
        /// </summary>
        [Description("Scale transformation")]
        Scale       = 2,

        /// <summary>
        /// Shear transformation.
        /// </summary>
        [Description("Shear transformation")]
        Shear       = 3
    }
}
