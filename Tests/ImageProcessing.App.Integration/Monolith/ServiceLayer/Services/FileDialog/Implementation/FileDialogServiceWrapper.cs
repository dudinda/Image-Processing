using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Code.Resources;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.FileDialog.Implementation
{
    internal class FileDialogServiceWrapper : IFileDialogServiceWrapper
    {
        public virtual Task<(Bitmap Image, string Path)> OpenFileDialog(string filters)
            => Task.FromResult((Res._1920x1080frame, nameof(Res._1920x1080frame)));

        public virtual Task SaveFileAsDialog(Bitmap src, string filters)
            => Task.CompletedTask;
    }
}
