namespace ImageProcessing.App.Domain.Services.FileDialog
{
    /// <summary>
    /// Bridge over the <see cref="IFileDialogService"/> to call modal windows
    /// without blocking the UI thread.
    /// </summary>
    public interface INonBlockDialogService : IFileDialogService
    {

    }
}
