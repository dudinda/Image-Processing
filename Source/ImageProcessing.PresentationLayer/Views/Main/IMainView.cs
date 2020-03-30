using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapContainer;
using ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapInfo;
using ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapZoom;
using ImageProcessing.PresentationLayer.Views.ViewComponent.Cursor;
using ImageProcessing.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.PresentationLayer.Views.ViewComponent.RgbMenu;

namespace ImageProcessing.PresentationLayer.Views.Main
{
    /// <summary>
    /// Represents the base behavior
    /// of the main window.
    /// </summary>
    public interface IMainView : IView,
        IError, IBitmapContainer, IColorMenu,
        IBitmapInfo, IBitmapZoom, ICursor
    {    
        /// <summary>
        /// Specifies a path to the opened file.
        /// </summary>
        string PathToFile { get; set; }

        void AddToUndoContainer((Bitmap changed, ImageContainer from) action);

        /// <summary>
        /// Adds an image, transformed by a distribution to
        /// the quality measure container.
        /// </summary>
        void AddToQualityMeasureContainer(Bitmap transformed);

    }
}
