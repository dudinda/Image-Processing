using System;
using System.Drawing;

using ImageProcessing.App.Domain.Models.Options;

namespace ImageProcessing.App.Domain.Win.Services.Draw
{
    public class DrawService : IDrawService
    {
        private Point _start;
        private Bitmap _working;
        private Graphics _graphics;
        private bool _disposed;

        private readonly PenOptions _options;
        private readonly object _lock = new();

        public DrawService(PenOptions options)
        {
            _options = options;
        }

        public Bitmap Source { get; private set; }

        public void Capture(Point start, Bitmap source)
        {
            _start = start;
            Source = source;
            _working = new Bitmap(source);
            lock (_lock)
            {
                _graphics = Graphics.FromImage(_working);
                _disposed = false;
            }
        }

        public Bitmap DrawRectangle(Point position)
        {
            lock (_lock)
            {
                if (_disposed)
                {
                    return Source;
                }
            }

            var opt = _options;
            using var pen = new Pen(opt.Color, opt.Width);
            pen.DashStyle = opt.DashStyle;
            _graphics.DrawRectangle(pen, GetRectangle(position));

            return _working;
        }

        public Rectangle GetRectangle(Point position)
        {
            var startX = Math.Min(_start.X, position.X);
            var startY = Math.Min(_start.Y, position.Y);
            var width = Math.Abs(_start.X - position.X);
            var height = Math.Abs(_start.Y - position.Y);
            return new Rectangle(startX, startY, width, height);
        }

        public void Clear()
        {
            lock (_lock)
            {
                if (!_disposed)
                {
                    _graphics.DrawImageUnscaled(Source, 0, 0);
                }
            }
        }

        public void Dispose()
        {
            lock (_lock)
            {
                _graphics.Dispose();
                _disposed = true;
            }
        }
    }
}
