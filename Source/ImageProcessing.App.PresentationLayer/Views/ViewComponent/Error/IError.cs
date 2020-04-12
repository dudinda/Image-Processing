namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error
{
    /// <summary>
    /// Represents a view component with an error.
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Show the error occured during
        /// the operation.
        /// </summary>
        /// <param name="message"></param>
        void ShowError(string message);
    }
}
