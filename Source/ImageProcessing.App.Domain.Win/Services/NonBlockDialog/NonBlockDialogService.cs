using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Services.NonBlockDialog;
using ImageProcessing.App.Domain.Services.StaTask;

namespace ImageProcessing.App.Domain.Win.NonBlockDialog.Implementation
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
        public async Task<(Bitmap? Image, string Path)> NonBlockOpen(string? filters)
        {
            var result = await _sta.StartSTATask(
                () => _dialog.OpenFileDialog(filters)
            ).ConfigureAwait(false);

            return await result.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task NonBlockSaveAs(Bitmap src, string filters)
        {
            await _sta.StartSTATask(
                 () => _dialog.SaveFileAsDialog(src, filters)
            ).ConfigureAwait(false);
        }
    }
}
