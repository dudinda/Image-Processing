using ImageProcessing.RGBFilters.Abstract;

using System.Drawing;

namespace ImageProcessing.DomainModel.Services.RGBFilter
{
    public interface IRGBFilterService
    {
        Bitmap Filter(Bitmap source, IRGBFilter filter);
    }
}
