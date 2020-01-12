using System.Drawing;

namespace ImageProcessing.RGBFilters.Interface
{
    public interface IRGBFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
