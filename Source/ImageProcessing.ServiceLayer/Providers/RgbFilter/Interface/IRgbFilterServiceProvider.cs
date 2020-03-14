using System.Drawing;
using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter
{
    public interface IRgbFilterServiceProvider
    {
        Bitmap Apply(Bitmap bmp, Common.Enums.RgbFilter filter);
        Bitmap Apply(Bitmap bmp, RgbColors filter);
    }
}
