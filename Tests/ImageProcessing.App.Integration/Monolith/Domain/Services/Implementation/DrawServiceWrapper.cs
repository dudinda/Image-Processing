using System.Drawing;

using ImageProcessing.App.Domain.Win.Services.Draw;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Implementation
{
    internal class DrawServiceWrapper : IDrawServiceWrapper
    {
        private readonly IDrawService _service;

        public DrawServiceWrapper(
            IDrawService service)
        {
            _service = service;
        }

        public virtual void Capture(Point start)
            => _service.Capture(start);

        public virtual Bitmap DrawRectangle(Bitmap bitmap, Point position)
            => _service.DrawRectangle(bitmap, position);

        public virtual Rectangle GetRectangle(Point position)
            => _service.GetRectangle(position);
       
    }
}
