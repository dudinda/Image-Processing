using System.Drawing;

namespace ImageProcessing.RGBFilters.Abstract
{
    public interface IRGBFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
