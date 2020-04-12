using System.Drawing;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.View;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapContainer;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapInfo;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapZoom;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Cursor;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.RgbMenu;

namespace ImageProcessing.App.PresentationLayer.Views.Main
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
