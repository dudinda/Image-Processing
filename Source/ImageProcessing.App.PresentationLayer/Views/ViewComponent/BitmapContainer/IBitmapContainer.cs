using System.Drawing;

using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapContainer
{
    /// <summary>
    /// Represents a view component with bitmap containers.
    /// </summary>
    public interface IBitmapContainer
    {
        /// <summary>
        /// A rendered image at the
        /// <see cref="ImageContainer.Source"/>.
        /// </summary>
        Image SrcImage { get; set; }

        /// <summary>
        /// A rendered image at the
        /// <see cref="ImageContainer.Destination"/>.
        /// </summary>
        Image DstImage { get; set; }

        /// <summary>
        /// A copy of a rendered image at the
        /// <see cref="ImageContainer.Source"/>.
        /// </summary>
        Image SrcImageCopy { get; set; }

        /// <summary>
        /// A copy of a rendered image at the
        /// <see cref="ImageContainer.Destination/>.
        /// </summary>
        Image DstImageCopy { get; set; }

        /// <summary>
        /// Get the specified image copy from
        /// the <see cref="ImageContainer"/>.
        /// </summary>
        Image GetImageCopy(ImageContainer container);

        /// <summary>
        /// Set the specified image copy
        /// at the <see cref="ImageContainer"/>.
        /// </summary>
        void SetImageCopy(ImageContainer container, Image copy);

        /// <summary>
        /// Set the specified <see cref="Image"/>
        /// at the <see cref="ImageContainer"/>.
        /// </summary>
        void SetImage(ImageContainer container, Image image);

        /// <summary>
        /// Check whether the specified image
        /// is null.
        /// </summary>
        bool ImageIsNull(ImageContainer container);

        /// <summary>
        /// Refresh the specified <see cref="ImageContainer"/>.
        /// </summary>
        void Refresh(ImageContainer container);
    }
}
