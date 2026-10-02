using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Providers.Rotation
{
    public interface IRotationProvider
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
