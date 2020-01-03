using System.Drawing;

namespace ImageProcessing.RGBFilter.Abstract
{
    public interface IRGBFilter
    {
        Bitmap Filter(Bitmap bitmap);
    }
}
