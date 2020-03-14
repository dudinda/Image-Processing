using System.Drawing;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Interface
{
    public interface IRGBFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
