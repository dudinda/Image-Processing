using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;

namespace ImageProcessing.App.ServiceLayer.Services.FileDialog
{
    /// <inheritdoc cref="IFileDialogService"/>
    public sealed class FileDialogService : IFileDialogService
    {
        /// <inheritdoc/>
        public async Task<(Bitmap? Image, string Path)> OpenFileDialog(string? filters)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                dialog.Filter = filters;
                dialog.AddExtension = true;
            
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return await Task.Run(
                        () =>(new Bitmap(dialog.FileName), dialog.FileName)
                    ).ConfigureAwait(false);
                }

                return await Task.FromResult<(Bitmap?, string)>(default).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task SaveFileAsDialog(Bitmap src, string? filters)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = filters;
                dialog.AddExtension = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var ext = Path.GetExtension(dialog.FileName).GetImageFormat();

                    await Task.Run(
                        () => src.Save(dialog.FileName, ext)
                    ).ConfigureAwait(false);
                }
            }
        }
    }
}
