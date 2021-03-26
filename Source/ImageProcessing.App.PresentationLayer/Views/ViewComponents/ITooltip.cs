namespace ImageProcessing.App.PresentationLayer.Views.ViewComponents
{
    /// <summary>
    /// Represents a view component with an error.
    /// </summary>
    public interface ITooltip
    {
        /// <summary>
        /// Show the error occured during
        /// the operation.
        /// </summary>
        /// <param name="message"></param>
        void Tooltip(string message);
    }
}
