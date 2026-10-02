using System.Drawing;

namespace ImageProcessing.App.Domain.Providers.Rotation
{
    public interface IRotationProvider
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
