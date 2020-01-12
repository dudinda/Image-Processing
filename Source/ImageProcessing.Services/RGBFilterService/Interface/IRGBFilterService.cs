using ImageProcessing.RGBFilters.Interface;

using System.Drawing;

namespace ImageProcessing.Services.RGBFilterService.Interface
{
    public interface IRGBFilterService
    {
        Bitmap Filter(Bitmap source, IRGBFilter filter);
    }
}
