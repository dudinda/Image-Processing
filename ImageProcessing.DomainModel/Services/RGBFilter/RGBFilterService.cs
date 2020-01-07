using System.Drawing;

using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.DomainModel.Services.RGBFilter
{
    public class RGBFilterService : IRGBFilterService
    {
        public Bitmap Filter(Bitmap source, IRGBFilter filter)
        {
            return filter.Filter(source);
        }
    }
}
