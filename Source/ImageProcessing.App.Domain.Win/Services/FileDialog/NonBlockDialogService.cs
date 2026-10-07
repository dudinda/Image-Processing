using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Services.StaTask;

namespace ImageProcessing.App.Domain.Win.Services.FileDialog
{
    /// <inheritdoc cref="INonBlockDialogService"/>
    public sealed class NonBlockDialogService : INonBlockDialogService
    {
        private readonly IFileDialogService _dialog;
        private readonly IStaTaskService _sta;

        public NonBlockDialogService(
            IFileDialogService dialog,
            IStaTaskService sta)
        {
            _dialog = dialog;
            _sta = sta;
        }

        /// <inheritdoc/>
        public async Task<(Bitmap? Image, string Path)> OpenFileDialog()
        {
            var result = await _sta.StartSTATask(
                () => _dialog.OpenFileDialog()
            ).ConfigureAwait(false);

            return await result.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task SaveFileAsDialog(Bitmap src)
        {
            await _sta.StartSTATask(
                 () => _dialog.SaveFileAsDialog(src)
            ).ConfigureAwait(false);
        }
    }
}
