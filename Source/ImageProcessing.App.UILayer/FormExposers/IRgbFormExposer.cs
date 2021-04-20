using ImageProcessing.App.UILayer.Forms.Rgb;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Rgb
{
    /// <summary>
    /// Expose elements from the <see cref="RgbForm"/>.
    /// </summary>
    internal interface IRgbFormExposer 
    {
        /// <summary>
        /// Select the filtering by the red channel.
        /// </summary>
        MetroCheckBox RedButton { get; }

        /// <summary>
        /// Select the filtering by the green channel.
        /// </summary>
        MetroCheckBox GreenButton { get; }

        /// <summary>
        /// Select the filtering by the blue channel.
        /// </summary>
        MetroCheckBox BlueButton { get; }

        /// <summary>
        /// Apply an rgb filter.
        /// </summary>
        MetroButton ApplyFilterButton { get; }

        /// <summary>
        /// Show the color matrix menu.
        /// </summary>
        MetroButton ColorMatrixMenuButton { get; }
    }
}