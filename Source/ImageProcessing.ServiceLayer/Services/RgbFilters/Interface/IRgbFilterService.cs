using System.Drawing;

using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.ServiceLayer.Services.RgbFilter.Interface
{
    public interface IRgbFilterService
    {
        Bitmap Filter(Bitmap source, IRgbFilter filter);
    }
}
