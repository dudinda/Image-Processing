using System.Drawing;
using System.Threading.Tasks;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services
{
    internal class NonBlockDialogServiceFake : INonBlockDialogService
    {
        public virtual Task<(Bitmap Image, string Path)> NonBlockOpen(string filters)
        {
            return Task.FromResult((default(Bitmap), default(string)));
        }

        public virtual Task NonBlockSaveAs(Bitmap src, string filters)
        {
            return Task.CompletedTask;
        }
    }
}
