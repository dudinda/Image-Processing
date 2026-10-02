using ImageProcessing.App.Presentation.Code.Enums;

namespace ImageProcessing.App.Presentation.Views.ViewComponents
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
