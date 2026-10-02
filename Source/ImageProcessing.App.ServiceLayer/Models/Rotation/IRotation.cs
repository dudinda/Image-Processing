using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Models.Rotation
{
    public interface IRotation
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
