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
        /// Set the path to the loaded image.
        /// </summary>
        void SetPathToFile(string path);

        /// <summary>
        /// Get the path of the loaded image.
        /// </summary>
        string GetPathToFile();

        /// <summary>
        /// Add the processed result of the <see cref="ImageContainer"/>.
        /// </summary>

        void AddToUndoRedo(ImageContainer to, Bitmap bmp, UndoRedoAction action);

        /// <summary>
        /// Undo/Redo the last operation.
        /// </summary>
        (Bitmap, ImageContainer) TryUndoRedo(UndoRedoAction action);
    }
}
