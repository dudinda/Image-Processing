using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.ServiceLayer.Services.BitmapCopyReference.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Implementation
{
    internal class BitmapCopyServiceWrapper : IBitmapCopyServiceWrapper
    {
        private readonly BitmapCopyService _service;
   
        public IAsyncOperationLockerWrapper Locker { get; }

        public BitmapCopyServiceWrapper(
            IAsyncOperationLockerWrapper locker)
        {
            _service = new BitmapCopyService(locker);
            Locker = locker;
        }

        public virtual Task<Bitmap> GetCopy()
        {
            return Task.FromResult(
                _service.GetCopy().Result);
        }

        public virtual Task SetCopy(Bitmap bmp)
        {
            _service.SetCopy(bmp).Wait();
            return Task.CompletedTask;
        }
    }
}
