using System.Drawing;

namespace ImageProcessing.App.DomainLayer.Models.Scaling.Interface
{
    public interface IScaling
    {
        Bitmap Resize(Bitmap bmp, double xScale, double yScale);
    }
}
