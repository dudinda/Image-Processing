using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.Cursor
{
    /// <summary>
    /// Represents a view component with a cursor.
    /// </summary>
    public interface ICursor
    {
        /// <summary>
        /// Set the specified <see cref="CursorType"/>.
        /// </summary>
        void SetCursor(CursorType cursor);
    }
}
