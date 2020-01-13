using System.Drawing;

using ImageProcessing.Core.Model.RGBFilters;

namespace ImageProcessing.Services.RGBFilterService.Interface
{
    public interface IRGBFilterService
    {
        Bitmap Filter(Bitmap source, IRGBFilter filter);
    }
}
