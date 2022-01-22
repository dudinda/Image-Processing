using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponents
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
        Image? SrcImage { get; set; }

        /// <summary>
        /// A copy of a rendered image at the
        /// <see cref="ImageContainer.Source"/>.
        /// </summary>
        Image? SrcImageCopy { get; set; }

        /// <summary>
        /// Get the specified image copy from
        /// the <see cref="ImageContainer"/>.
        /// </summary>
        Image GetImageCopy();

        /// <summary>
        /// Set the specified image copy
        /// at the <see cref="ImageContainer"/>.
        /// </summary>
        void SetImageCopy(Image copy);

        /// <summary>
        /// Set the specified <see cref="Image"/>
        /// at the <see cref="ImageContainer"/>.
        /// </summary>
        void SetImage(Image image);

        /// <summary>
        /// Check whether the specified image
        /// is null.
        /// </summary>
        bool ImageIsDefault();

        /// <summary>
        /// Refresh the specified <see cref="ImageContainer"/>.
        /// </summary>
        void Refresh();
    }
}
