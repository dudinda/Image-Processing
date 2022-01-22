using System;
using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents the base behavior
    /// of the main window.
    /// </summary>
    public interface IMainView : IView, ITrackBarContainer,
        ITooltip, IBitmapContainer, ICursor, IDisposable
    {
        /// <summary>
        /// Default an image inside a picturebox./>
        /// </summary>
        void SetDefaultImage();

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
        void AddToUndoRedo(Bitmap bmp, UndoRedoAction action);

        /// <summary>
        /// Undo/Redo the last operation.
        /// </summary>
        Bitmap TryUndoRedo(UndoRedoAction action);

        /// <summary>
        /// Center a picturebox after a scaling.
        /// </summary>
        void SetImageCenter(Size size);

        /// <summary>
        /// Set the state for the main view buttons.
        /// </summary>
        /// <param name="state"></param>
        void SetMenuState(MenuBtnState state);
    }
}
