namespace ImageProcessing.Core.MVP.View
{
    /// <summary>
    /// Represents the base behavior
    /// of a view.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Show a view.
        /// </summary>
        void Show();

        /// <summary>
        /// Close a view.
        /// </summary>
        void Close();
    }
}
