using System.Drawing;

namespace ImageProcessing.App.Domain.Win.Services.Draw
{
    public interface IDrawService
    {
        void Capture(Point start);
        Bitmap DrawRectangle(Bitmap bitmap, Point position);
        Rectangle GetRectangle(Point position);
    }
}
