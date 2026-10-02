using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Providers.Scaling
{
    public interface IScalingProvider
    {
        Bitmap Scale(Bitmap bmp, double xScale, double yScale);
        Bitmap Scale(Bitmap bmp, double xScale, double yScale, ScalingMethod method);
    }
}
