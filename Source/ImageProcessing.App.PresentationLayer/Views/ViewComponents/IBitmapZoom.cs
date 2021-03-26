using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponents
{
    /// <summary>
    /// Represents a view component with a trackbars.
    /// </summary>
    public interface ITrackBarContainer
    {
        /// <summary>
        /// Reset trackbars values after
        /// an <see cref="ImageContainer"/> rendering. 
        /// </summary>
        void ResetTrackBarValue(ImageContainer container, int value = 0);

        /// <summary>
        /// Get a zoom factor value from the <see cref="ImageContainer"/>. 
        /// </summary>
        double GetZoomFactor(ImageContainer container);

        /// <summary>
        /// Get a rotation factor value from the <see cref="ImageContainer"/>. 
        /// </summary>
        double GetRotationFactor(ImageContainer container);
    }
}
