using System.Drawing;

using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.ServiceLayer.Services.RgbFilter.Interface
{
    public interface IRGBFilterService
    {
        Bitmap Filter(Bitmap source, IRGBFilter filter);
    }
}
