using System;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.BitmapContainer;
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
        ITooltip, IBitmapContainer,
        ICursor, IDisposable
    {
        /// <summary>
        /// Specifies a path to the opened file.
        /// </summary>
        public string PathToFile { get; }
     
        void SetPathToFile(string path);

        void AddToUndo(ImageContainer to);

        void AddToRedo(ImageContainer to);

        bool TryUndoRedo(UndoRedoAction action, out (Bitmap, ImageContainer) result);
    }
}
