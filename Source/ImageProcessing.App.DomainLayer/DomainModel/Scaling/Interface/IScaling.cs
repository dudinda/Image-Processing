using System.Drawing;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface
{
    public interface IScaling
    {
        Bitmap Resize(Bitmap bmp, double xScale, double yScale);
    }
}
