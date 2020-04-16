using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    public enum StructuringElem
    {
        /// <summary>
        /// An unknown kernel type.
        /// </summary>
        [Description("Kernel is not specified")]
        Unknown     = 0,

        /// <summary>
        /// Rectangular kernel. Where Aij = 1.
        /// </summary>
        [Description("Rectangular")]
        Rectangular = 1,

        /// <summary>
        /// Elliptical kernel. Where Aij represents a filled ellipse
        /// inscribed into the kernel.
        /// </summary>
        [Description("Elliptical")]
        Elliptical  = 2,

        /// <summary>
        /// Cross-shaped kernel. 
        /// </summary>
        [Description("Cross-shaped")]
        CrossShaped = 3
    }
}
