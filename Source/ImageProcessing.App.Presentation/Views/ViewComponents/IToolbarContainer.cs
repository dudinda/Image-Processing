using System.Drawing;

using ImageProcessing.App.Presentation.Code.Enums;

namespace ImageProcessing.App.Presentation.Views.ViewComponents
{
    public interface IToolbarContainer
    {
        Image LoadedImage { get; set; }

        public bool IsCaptureRegion { get; }

        /// <summary>
        /// Add the processed result of the <see cref="ImageContainer"/>.
        /// </summary>
        void AddToUndoRedo(Bitmap bmp, UndoRedoAction action);

        /// <summary>
        /// Undo/Redo the last operation.
        /// </summary>
        Bitmap TryUndoRedo(UndoRedoAction action);
    }
}
