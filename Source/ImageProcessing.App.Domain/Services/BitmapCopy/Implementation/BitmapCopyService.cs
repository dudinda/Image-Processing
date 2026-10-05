using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Locker;

namespace ImageProcessing.App.Domain.Services.BitmapCopyReference.Implementation
{
    public sealed class BitmapCopyService : IBitmapCopyService
    {
        private readonly IAsyncOperationLocker _locker;

        private Bitmap? _cpy;

        public BitmapCopyService(
            IAsyncOperationLocker locker)
        {
            _locker = locker;
        }

        public async Task<Bitmap> GetCopy()
        {
            var copy = await _locker.LockOperationAsync(
                () => new Bitmap(_cpy), CancellationToken.None
            ).ConfigureAwait(false);

            return copy;
        }

        public async Task SetCopy(Bitmap cpy)
        {
            var copy = await _locker.LockOperationAsync(
                () => _cpy = new Bitmap(cpy), CancellationToken.None
            ).ConfigureAwait(false);
        }
    }
}
