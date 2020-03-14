using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution
{
    public interface IBitmapLuminanceDistributionServiceProvider
    {
        Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms);
        decimal GetInfo(Bitmap bmp, RandomVariable info);
    }
}
