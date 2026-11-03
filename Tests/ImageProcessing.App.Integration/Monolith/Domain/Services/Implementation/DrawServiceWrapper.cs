using System.Drawing;

using ImageProcessing.App.Domain.Win.Services.Draw;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Implementation
{
    internal class DrawServiceWrapper : IDrawServiceWrapper
    {
        private readonly IDrawService _service;
        public virtual Bitmap Source { get => _service.Source; private set; }

        public DrawServiceWrapper(
            IDrawService service)
        {
            _service = service;
        }

        public virtual void Capture(Point start, Bitmap bitmap)
            => _service.Capture(start, bitmap);

        public virtual Bitmap DrawRectangle(Point position)
            => _service.DrawRectangle(position);

        public virtual Rectangle GetRectangle(Point position)
            => _service.GetRectangle(position);

        public virtual void Clear()
            => _service.Clear();

        public virtual void Dispose()
            => _service.Dispose();
    }
}
