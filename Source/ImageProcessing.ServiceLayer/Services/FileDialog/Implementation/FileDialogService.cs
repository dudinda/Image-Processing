using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.ServiceLayer.Services.FileDialog.Interface;

namespace ImageProcessing.ServiceLayer.Services.FileDialog.Implementation
{
    public class FileDialogService : IFileDialogService
    {
        public async Task<Bitmap> OpenFileDialog(string filters)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal
                );

                dialog.Filter = filters;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return await Task.Run(() =>
                    {
                        using (var stream = File.OpenRead(dialog.FileName))
                        {
                            return new Bitmap(
                                Image.FromStream(stream)
                            );
                        }
                    });              
                }

                return await Task.FromResult<Bitmap>(null);
            }
        }

        public async Task SaveFileAsDialog(Bitmap src, string filters)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = filters;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    await Task.Run(() =>
                    {
                       src.Save(dialog.FileName,
                                Path.GetExtension(
                                    dialog.FileName
                                ).GetImageFormat()
                          );
                    });
                }
            }
        }
    }
}
