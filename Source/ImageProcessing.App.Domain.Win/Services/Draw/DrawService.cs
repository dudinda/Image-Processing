using System;
using System.Drawing;

using ImageProcessing.App.Domain.Models.Options;

namespace ImageProcessing.App.Domain.Win.Services.Draw
{
    public class DrawService : IDrawService
    {
        private Point _start;

        private readonly PenOptions _options;

        public DrawService(PenOptions options)
        {
            _options = options;
        }

        public void Capture(Point start)
        {
            _start = start;
        }

        public Bitmap DrawRectangle(Bitmap bitmap, Point position)
        {
            var opt = _options;
            using var graphics = Graphics.FromImage(bitmap);
            using var pen = new Pen(opt.Color, opt.Width);
            pen.DashStyle = opt.DashStyle;
            graphics.DrawRectangle(pen, GetRectangle(position));
            return bitmap;
        }

        public Rectangle GetRectangle(Point position)
        {
            var startX = Math.Min(_start.X, position.X);
            var startY = Math.Min(_start.Y, position.Y);
            var width = Math.Abs(_start.X - position.X);
            var height = Math.Abs(_start.Y - position.Y);
            return new Rectangle(startX, startY, width, height);
        }
    }
}
