using ImageProcessing.App.PresentationLayer.Views.Rgb;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormControls.Rgb
{
    /// <summary>
    /// Expose elements from the rgb form.
    /// </summary>
    internal interface IRgbElementExposer : IRgbView
    {
        /// <summary>
        /// Select the filtering by the red channel.
        /// </summary>
        MetroRadioButton RedButton { get; }

        /// <summary>
        /// Select the filtering by the green channel.
        /// </summary>
        MetroRadioButton GreenButton { get; }

        /// <summary>
        /// Select the filtering by the blue channel.
        /// </summary>
        MetroRadioButton BlueButton { get; }

        /// <summary>
        /// Apply an rgb filter.
        /// </summary>
        MetroButton ApplyFilterButton { get; }
    }
}
