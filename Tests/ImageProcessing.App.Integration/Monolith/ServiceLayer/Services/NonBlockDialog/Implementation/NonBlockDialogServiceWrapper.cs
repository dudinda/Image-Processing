using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services
{
    internal class NonBlockDialogServiceWrapper : INonBlockDialogServiceWrapper
    {
        public IFileDialogServiceWrapper Service { get; }
        public IStaTaskServiceWrapper Sta { get; }

        public NonBlockDialogServiceWrapper(
            IFileDialogServiceWrapper service,
            IStaTaskServiceWrapper sta)
        {
            Service = service;
            Sta = sta;
        }

        public virtual async Task<(Bitmap Image, string Path)> NonBlockOpen(string filters)
        {
            var args = await Service.OpenFileDialog(filters).ConfigureAwait(false);

            return await Task.FromResult(args);
        }

        public virtual async Task NonBlockSaveAs(Bitmap src, string filters)
        {

        }
    }
}
