using System.Drawing;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Interface
{
    public interface IRgbFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
