using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Implementation
{
    internal class FileDialogServiceWrapper : IFileDialogServiceWrapper
    {
        public virtual Task<(Bitmap Image, string Path)> OpenFileDialog()
            => Task.FromResult((Res._1920x1080frame, nameof(Res._1920x1080frame)));

        public virtual Task SaveFileAsDialog(Bitmap src)
            => Task.CompletedTask;
    }
}
