using System.Drawing;

namespace ImageProcessing.App.Domain.Models.Rotation
{
    public interface IRotation
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
