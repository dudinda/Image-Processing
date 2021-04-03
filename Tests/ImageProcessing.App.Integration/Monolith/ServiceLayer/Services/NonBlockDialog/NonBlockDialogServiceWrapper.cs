using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.TestResources;
using ImageProcessing.App.ServiceLayer.Win.NonBlockDialog.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.StaTask.Interface;

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
