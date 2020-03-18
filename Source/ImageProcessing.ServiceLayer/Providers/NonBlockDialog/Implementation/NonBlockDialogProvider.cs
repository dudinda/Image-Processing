using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Helpers;
using ImageProcessing.ServiceLayer.Providers.Operation.Interface;
using ImageProcessing.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.ServiceLayer.Services.StaTask.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Operation.Implementation
{
    public sealed class NonBlockDialogProvider : INonBlockDialogProvider
    {
        private readonly IFileDialogService _service;
        private readonly ISTATaskService _staService;

        public NonBlockDialogProvider(IFileDialogService service,
                                      ISTATaskService staService)
        {
            _service    = Requires.IsNotNull(
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
