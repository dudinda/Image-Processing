using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.RgbMenu
{
    /// <summary>
    /// Represents a view component with a rgb color menu.
    /// </summary>
    public interface IColorMenu
    {
        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        RgbColors GetSelectedColors(RgbColors color);
    }
}
