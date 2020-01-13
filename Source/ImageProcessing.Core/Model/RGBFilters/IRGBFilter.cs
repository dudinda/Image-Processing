using System.Drawing;

namespace ImageProcessing.Core.Model.RGBFilters
{
    public interface IRGBFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
