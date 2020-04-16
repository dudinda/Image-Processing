using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.Cursor
{
    /// <summary>
    /// Represents a view component with a cursor.
    /// </summary>
    public interface ICursor
    {
        void SetCursor(CursorType cursor);
    }
}
