using System.Drawing;

namespace ImageProcessing.App.DomainLayer.Models.Rotation.Interface
{
    public interface IRotation
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
