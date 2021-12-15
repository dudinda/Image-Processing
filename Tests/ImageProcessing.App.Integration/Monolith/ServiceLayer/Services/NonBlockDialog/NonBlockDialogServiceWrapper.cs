using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.ServiceLayer.Services.FileDialog;
using ImageProcessing.App.ServiceLayer.Services.StaTask;
using ImageProcessing.App.ServiceLayer.Win.NonBlockDialog.Implementation;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services
{
    internal class NonBlockDialogServiceWrapper : NonBlockDialogService
    {
        public NonBlockDialogServiceWrapper(
            IFileDialogService service,
            IStaTaskService staService) : base(service, staService)
        {

        }

        public override Task<(Bitmap Image, string Path)> NonBlockOpen(string filters)
            => Task.FromResult((Res._1920x1080frame, nameof(Res._1920x1080frame)));

        public async override Task NonBlockSaveAs(Bitmap src, string filters)
        {

        }
    }
}
