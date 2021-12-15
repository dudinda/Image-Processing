using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Implementation
{
    internal class BitmapServiceWrapper : IBitmapServiceWrapper
    {
        private readonly BitmapService _service = new BitmapService();

        public virtual Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative)
            => _service.Magnitude(xDerivative, yDerivative);

        public virtual byte Max(Bitmap bitmap)
            => _service.Max(bitmap);

        public virtual byte Min(Bitmap bitmap)
            => _service.Min(bitmap);

        public virtual Bitmap Normalize(Bitmap bitmap)
            => _service.Normalize(bitmap);

        public virtual Bitmap Shuffle(Bitmap bitmap)
            => _service.Shuffle(bitmap);
    }
}
