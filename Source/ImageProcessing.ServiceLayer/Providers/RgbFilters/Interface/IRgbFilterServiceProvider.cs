using System.Drawing;
using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Providers.Interface.RgbFilters
{
    public interface IRgbFilterServiceProvider
    {
        Bitmap Apply(Bitmap bmp, RgbFilter filter);
        Bitmap Apply(Bitmap bmp, RgbColors filter);
    }
}
