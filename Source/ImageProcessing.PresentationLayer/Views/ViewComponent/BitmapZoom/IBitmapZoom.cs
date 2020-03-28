using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapZoom
{
    public interface IBitmapZoom
    {
        /// <summary>
        /// Reset the zoom trackbar value after
        /// the <see cref="ImageContainer"/> rendering. 
        /// </summary>
        void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true);

        /// <summary>
        /// Perform the zoom of the specified
        /// <see cref="ImageContainer"/>.
        /// </summary>
        Image ZoomImage(ImageContainer container);

        /// <summary>
        /// Set the specified <see cref="Image"/> to the selected <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="image"></param>
        void SetImageToZoom(ImageContainer container, Image image);
    }
}
