using System;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapContainer;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapInfo;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapZoom;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Cursor;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Main
{
    /// <summary>
    /// Represents the base behavior
    /// of the main window.
    /// </summary>
    public interface IMainView : IView, IBitmapZoom,
        ITooltip, IBitmapContainer, IBitmapInfo,
        ICursor, IDisposable
    {
        /// <summary>
        /// Specifies a path to the opened file.
        /// </summary>
        public string PathToFile { get; }
     
        void SetPathToFile(string path);

        void AddToUndoContainer((Bitmap changed, ImageContainer from) action);
    }
}
