using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Providers.Rotation
{
    public interface IRotationProvider
    {
        Bitmap Rotate(Bitmap bmp, double angle);
        Bitmap Rotate(Bitmap bmp, double angle, RotationMethod method);
    }
}
