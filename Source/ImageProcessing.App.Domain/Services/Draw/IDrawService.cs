using System;
using System.Drawing;

namespace ImageProcessing.App.Domain.Win.Services.Draw
{
    public interface IDrawService : IDisposable
    {
        public Bitmap Source { get; }
        void Capture(Point start, Bitmap bitmap);
        Bitmap DrawRectangle(Point position);
        Rectangle GetRectangle(Point position);
        void Clear();
    }
}
