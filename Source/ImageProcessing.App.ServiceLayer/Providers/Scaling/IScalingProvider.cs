using System.Drawing;

using ImageProcessing.App.ServiceLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling
{
    public interface IScalingProvider
    {
        Bitmap Scale(Bitmap bmp, double xScale, double yScale);
        Bitmap Scale(Bitmap bmp, double xScale, double yScale, ScalingMethod method);
    }
}
