using System.Drawing;

namespace ImageProcessing.Services.Abstract
{
    public interface IRGBFilterService
    {
        Bitmap Filter(Bitmap source, IRGBFilter filter);
    }
}
