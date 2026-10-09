using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.StaTask.Interface;

namespace ImageProcessing.App.Presentation.UnitTests.Fakes.Services
{
    internal class NonBlockDialogServiceWrapper : INonBlockDialogServiceWrapper
    {
        public OpenDialogOptions Options { get; }
        public IFileDialogServiceWrapper Service { get; }
        public IStaTaskServiceWrapper Sta { get; }

        public NonBlockDialogServiceWrapper(
            IFileDialogServiceWrapper service,
            IStaTaskServiceWrapper sta)
        {
            Service = service;
            Sta = sta;
        }

        public virtual Task<(Bitmap Image, string Path)> OpenFileDialog()
        {
            var args = Sta.StartSTATask(async () =>
            {
                var args = await Service.OpenFileDialog();
                return args;
            });

            return args.Result;
        }

        public virtual Task SaveFileAsDialog(Bitmap src)
        {
            var task = Sta.StartSTATask(async () =>
            {
                await  Service.SaveFileAsDialog(src);
            });

            return task.Result;
        }
    }
}
