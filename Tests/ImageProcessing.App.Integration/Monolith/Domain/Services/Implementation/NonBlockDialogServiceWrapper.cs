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
            var args = Sta.StartSTATask(() =>
            {
                var args = Service.OpenFileDialog().Result;
                return Task.FromResult(args);
            });

            return args.Result;
        }

        public virtual Task SaveFileAsDialog(Bitmap src)
        {
            var task = Sta.StartSTATask(() =>
            {
                Service.SaveFileAsDialog(src);
                return Task.CompletedTask;
            });

            return task.Result;
        }
    }
}
