using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Models.Thresholding
{
    public interface IThreshold
    {
        Bitmap Segment(Bitmap src, byte threshold);
    }
}
