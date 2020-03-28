using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapContainer
{
    public interface IBitmapContainer
    {
        /// <summary>
        /// The rendered image at the
        /// <see cref="ImageContainer.Source"/>.
        /// </summary>
        Image SrcImage { get; set; }

        /// <summary>
        /// The rendered image at the
        /// <see cref="ImageContainer.Destination"/>.
        /// </summary>
        Image DstImage { get; set; }

        /// <summary>
        /// The copy of the rendered image at
        /// <see cref="ImageContainer.Source"/>.
        /// </summary>
        Image SrcImageCopy { get; set; }

        /// <summary>
        /// The copy of the rendered image at
        /// <see cref="ImageContainer.Destination/>.
        /// </summary>
        Image DstImageCopy { get; set; }

        /// <summary>
        /// Get the specified image copy from
        /// the <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        Image GetImageCopy(ImageContainer container);

        /// <summary>
        /// Set the specified image copy
        /// from the <see cref="ImageContainer"/>.
        /// </summary>
        void SetImageCopy(ImageContainer container, Image copy);

        /// <summary>
        /// Set the specified 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="image"></param>
        void SetImage(ImageContainer container, Image image);

        /// <summary>
        /// Check whether the specified image
        /// is null.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        bool ImageIsNull(ImageContainer container);

        /// <summary>
        /// Refresh the specified <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="container"></param>
        void Refresh(ImageContainer container);
    }
}
