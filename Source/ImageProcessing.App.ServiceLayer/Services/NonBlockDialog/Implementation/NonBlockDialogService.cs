using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;

namespace ImageProcessing.App.ServiceLayer.NonBlockDialog.Implementation
{
    public sealed class NonBlockDialogService : INonBlockDialogService
    {
        private readonly IFileDialogService _service;
        private readonly IStaTaskService _staService;

        public NonBlockDialogService(IFileDialogService service,
                                     IStaTaskService staService)
        {
            _service = Requires.IsNotNull(
                service, nameof(service));
            _staService = Requires.IsNotNull(
                staService, nameof(staService));
        }

        public async Task<Bitmap> NonBlockOpen(string filters)
        {
            var result = await _staService.StartSTATask(
                () => _service.OpenFileDialog(filters)
            ).ConfigureAwait(false);

            return await result.ConfigureAwait(false);
        }

        public async Task NonBlockSaveAs(Bitmap src, string filters)
        {
            Requires.IsNotNull(src, nameof(src));

            await _staService.StartSTATask(
                 () => _service.SaveFileAsDialog(src, filters)
            ).ConfigureAwait(false);          
        }
    }
}
