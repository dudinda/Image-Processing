using ImageProcessing.Common.Enums;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.Cursor
{
    /// <summary>
    /// Represents a view component with a cursor.
    /// </summary>
    public interface ICursor
    {
        /// <summary>
        /// Update cursor to a <see cref="CursorType"/>.
        /// </summary>
        /// <param name="cursor"></param>
        void SetCursor(CursorType cursor);
    }
}
