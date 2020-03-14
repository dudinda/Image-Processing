using System.Drawing;
using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter
{
    public interface IRgbFilterServiceProvider
    {
        Bitmap Apply(Bitmap bmp, RGBFilter filter);
        Bitmap Apply(Bitmap bmp, RGBColors filter);
    }
}
