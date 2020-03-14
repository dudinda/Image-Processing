using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        /// <summary>
        /// Parameters is used during the histogram
        /// transorfmation by a specified distribution.
        /// </summary>
        (string, string) Parameters { get; }

        /// <summary>
        /// Specifies a path to the opened file.
        /// </summary>
        string PathToFile { get; set; }

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
        /// Adds 
        /// </summary>
        void AddToUndoContainer((Bitmap changed, ImageContainer from) action);

        /// <summary>
        /// Adds an image, transformed by a distribution to
        /// the quality measure container.
        /// </summary>
        void AddToQualityMeasureContainer(Bitmap transformed);

        /// <summary>
        /// Get the 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        RgbColors GetSelectedColors(RgbColors color);

        /// <summary>
        /// Show the information about <see cref="RandomVariable"/>
        /// value of the specified <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="info"></param>
        void ShowInfo(string info);

        /// <summary>
        /// Show the error occured during
        /// the operation.
        /// </summary>
        /// <param name="message"></param>
        void ShowError(string message);

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
        /// Reset the zoom trackbar value after
        /// the <see cref="ImageContainer"/> rendering. 
        /// </summary>
        void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true);

        /// <summary>
        /// Perform the zoom of the specified
        /// <see cref="ImageContainer"/>.
        /// </summary>
        Image ZoomImage(ImageContainer container);


        void SetImageToZoom(ImageContainer container, Image image);
        void SetCursor(CursorType cursor);

        /// <summary>
        /// Refresh the specified <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="container"></param>
        void Refresh(ImageContainer container);
    }
}
