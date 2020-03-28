namespace ImageProcessing.PresentationLayer.Views.ViewComponent.Error
{
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
