using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface
{
    public interface IScalingProvider
    {
        Bitmap Scale(Bitmap bmp, double xScale, double yScale);
        Bitmap Scale(Bitmap bmp, double xScale, double yScale, ScalingMethod method);
    }
}
