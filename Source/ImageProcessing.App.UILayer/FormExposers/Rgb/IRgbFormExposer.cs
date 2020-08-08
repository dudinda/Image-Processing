using ImageProcessing.App.PresentationLayer.Views.Rgb;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Exposers.Rgb
{
    /// <summary>
    /// Expose elements from the rgb form.
    /// </summary>
    internal interface IRgbFormExposer : IRgbView
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
    }
}
