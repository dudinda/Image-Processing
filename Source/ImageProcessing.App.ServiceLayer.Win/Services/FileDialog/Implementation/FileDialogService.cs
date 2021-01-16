using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions.BitmapExt;

namespace ImageProcessing.App.ServiceLayer.Services.FileDialog.Implementation
{
    /// <inheritdoc cref="IFileDialogService"/>
    public sealed class FileDialogService : IFileDialogService
    {
        /// <inheritdoc/>
        public async Task<(Bitmap? Image, string Path)> OpenFileDialog(string? filters)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                dialog.Filter = filters;
                dialog.AddExtension = true;
            
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return await Task.Run(() =>
                    {
                        return (new Bitmap(dialog.FileName), dialog.FileName);
                        
                    }).ConfigureAwait(false);              
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

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await Task.Run(() =>
                        src.Save(dialog.FileName, Path.GetExtension(dialog.FileName).GetImageFormat())
                    ).ConfigureAwait(false);
                }
            }
        }
    }
}
