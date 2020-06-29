using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface
{
    /// <summary>
    /// Bridge over the <see cref="IFileDialogService"/> to call modal windows
    /// without blocking the UI thread.
    /// </summary>
    public interface INonBlockDialogService
    {
        /// <summary>
        ///Init the <see cref="System.Windows.Forms.OpenFileDialog"/> without block.
        /// </summary>
        Task<(Bitmap? Image, string Path)> NonBlockOpen(string filters);

        /// <summary>
        ///Init the <see cref="System.Windows.Forms.SaveFileDialog"/> without block.
        /// </summary>
        Task NonBlockSaveAs(Bitmap src, string filters);
    }
}
