using System.Drawing;
using System.Threading.Tasks;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Frames;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services
{
    internal class NonBlockDialogServiceFake : INonBlockDialogService
    {
        public virtual Task<(Bitmap Image, string Path)> NonBlockOpen(string filters)
        {
            return Task.FromResult((Res._1920x1080frame, nameof(Res._1920x1080frame)));
        }

        public virtual Task NonBlockSaveAs(Bitmap src, string filters)
        {
            return Task.CompletedTask;
        }
    }
}
