using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.FileDialog;

namespace ImageProcessing.App.Domain.Services.NonBlockDialog
{
    /// <summary>
    /// Bridge over the <see cref="IFileDialogService"/> to call modal windows
    /// without blocking the UI thread.
    /// </summary>
    public interface INonBlockDialogService
    {
        /// <summary>
        ///Init the open file dialog without block.
        /// </summary>
        Task<(Bitmap? Image, string Path)> NonBlockOpen(string filters);

        /// <summary>
        ///Init the save file dialog without block.
        /// </summary>
        Task NonBlockSaveAs(Bitmap src, string filters);
    }
}
