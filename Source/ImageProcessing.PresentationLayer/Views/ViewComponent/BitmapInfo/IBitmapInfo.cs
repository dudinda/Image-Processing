using ImageProcessing.Common.Enums;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapInfo
{
    /// <summary>
    /// Represents a view component with a bitmap distribution info.
    /// </summary>
    public interface IBitmapInfo
    {
        /// <summary>
        /// Parameters used during the histogram
        /// transorfmation by a specified distribution.
        /// </summary>
        (string, string) Parameters { get; }

        /// <summary>
        /// Show the information about <see cref="RandomVariable"/>
        /// value of the specified <see cref="ImageContainer"/>.
        /// </summary>
        void ShowInfo(string info);
    }
}
