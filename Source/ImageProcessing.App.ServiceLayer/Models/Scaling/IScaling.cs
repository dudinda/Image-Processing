using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Models.Scaling
{
    public interface IScaling
    {
        Bitmap Resize(Bitmap bmp, double xScale, double yScale);
    }
}
