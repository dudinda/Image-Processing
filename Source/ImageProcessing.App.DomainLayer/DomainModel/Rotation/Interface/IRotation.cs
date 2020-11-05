using System.Drawing;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface
{
    public interface IRotation
    {
        Bitmap Rotate(Bitmap bmp, double angle);
    }
}
