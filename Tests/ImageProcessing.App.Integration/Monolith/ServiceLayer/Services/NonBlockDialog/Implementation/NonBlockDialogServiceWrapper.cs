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

        public virtual Task<(Bitmap Image, string Path)> NonBlockOpen(string filters)
        {
            var args = Sta.StartSTATask(() =>
            {
                var args = Service.OpenFileDialog(filters).Result;
                return Task.FromResult(args);
            });

            return args.Result;
        }

        public virtual Task NonBlockSaveAs(Bitmap src, string filters)
        {
            var task = Sta.StartSTATask(() =>
            {
                Service.SaveFileAsDialog(src, filters);
                return Task.CompletedTask;
            });

            return task.Result;
        }
    }
}
