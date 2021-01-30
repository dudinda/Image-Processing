using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface
{
    public interface IScalingProvider
    {
        Bitmap Scale(Bitmap bmp, double xScale, double yScale);
    }
}
