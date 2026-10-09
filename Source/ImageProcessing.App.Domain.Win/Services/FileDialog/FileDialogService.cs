using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Win.Code.Extensions;

namespace ImageProcessing.App.Domain.Win.Services.FileDialog
{
    /// <inheritdoc cref="IFileDialogService"/>
    public sealed class FileDialogService : IFileDialogService
    {
        private readonly OpenDialogOptions _options;

        public FileDialogService(OpenDialogOptions options)
        {
            _options = options;
        }

        /// <inheritdoc/>
        public async Task<(Bitmap? Image, string Path)> OpenFileDialog()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                dialog.Filter =  _options.Filters;
                dialog.AddExtension = _options.AddExtension;
            
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = dialog.FileName;
                    return await Task.Run(() =>(new Bitmap(fileName), fileName)).ConfigureAwait(false);
                }

                return await Task.FromResult<(Bitmap?, string)>(default).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task SaveFileAsDialog(Bitmap src)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = _options.Filters;
                dialog.AddExtension = _options.AddExtension;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = dialog.FileName;
                    var ext = Path.GetExtension(fileName).GetImageFormat();
                    await Task.Run(() => src.Save(fileName, ext) ).ConfigureAwait(false);
                }
            }
        }
    }
}
