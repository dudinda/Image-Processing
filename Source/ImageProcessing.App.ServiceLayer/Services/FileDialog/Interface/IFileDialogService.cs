using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface
{
    /// <summary>
    /// Service provides actions for the <see cref="System.Windows.Forms.FileDialog"/>. 
    /// </summary>
    internal interface IFileDialogService
    {
        /// <summary>
        /// Init the <see cref="System.Windows.Forms.OpenFileDialog"/>.
        /// </summary>
        Task<(Bitmap? Image, string Path)> OpenFileDialog(string? filters);

        /// <summary>
        /// Init the <see cref="System.Windows.Forms.SaveFileDialog"/>.
        /// </summary>
        Task SaveFileAsDialog(Bitmap src, string? filters);
    }
}
