using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Core.ServiceLayer.Providers.BitmapDistribution
{
    public interface IBitmapLuminanceDistributionServiceProvider
    {
        Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms);
        decimal GetInfo(Bitmap bmp, RandomVariable info);
    }
}
