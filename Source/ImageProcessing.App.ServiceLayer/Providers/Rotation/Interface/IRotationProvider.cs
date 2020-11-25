using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface
{
    public interface IRotationProvider
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
