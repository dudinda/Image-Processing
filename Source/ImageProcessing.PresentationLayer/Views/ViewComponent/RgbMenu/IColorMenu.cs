using ImageProcessing.Common.Enums;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.RgbMenu
{
    public interface IColorMenu
    {
        /// <summary>
        /// Green color channel is selected.
        /// </summary>
        bool IsGreenChannelChecked { get; set; }

        /// <summary>
        /// Red color channel is selected.
        /// </summary>
        bool IsRedChannelChecked { get; set; }

        /// <summary>
        /// Blue color channel is selected.
        /// </summary>
        bool IsBlueChannelChecked { get; set; }

        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        RgbColors GetSelectedColors(RgbColors color);
    }
}
