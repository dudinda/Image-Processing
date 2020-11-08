using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapZoom
{
    /// <summary>
    /// Represents a view component with a zoom menu.
    /// </summary>
    public interface IBitmapZoom
    {
        /// <summary>
        /// Reset a zoom trackbar value after
        /// an <see cref="ImageContainer"/> rendering. 
        /// </summary>
        void ResetTrackBarValue(ImageContainer container, int value = 0);

        /// <summary>
        /// Get a zoom factor value from the <see cref="ImageContainer"/>. 
        /// </summary>
        double GetTrackBarValue(ImageContainer container);

        /// <summary>
        /// Set the specified <see cref="Image"/> to
        /// the selected <see cref="ImageContainer"/>.
        void SetImageToZoom(ImageContainer container, Image image);
    }
}
