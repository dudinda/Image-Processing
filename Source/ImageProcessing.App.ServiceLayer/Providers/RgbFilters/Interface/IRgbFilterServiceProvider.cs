using System.Drawing;
using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters
{
    public interface IRgbFilterServiceProvider
    {
        Bitmap Apply(Bitmap bmp, RgbFilter filter);
        Bitmap Apply(Bitmap bmp, RgbColors filter);
    }
}
