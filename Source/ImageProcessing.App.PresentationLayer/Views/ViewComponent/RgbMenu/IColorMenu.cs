using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.RgbMenu
{
    /// <summary>
    /// Represents a view component with a rgb color menu.
    /// </summary>
    public interface IColorMenu
    {
        /// <summary>
        /// Get a color combination from the
        /// rgb colors menu.
        /// </summary>
        RgbColors GetSelectedColors(RgbColors color);
    }
}
