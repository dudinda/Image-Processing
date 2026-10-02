using System.Drawing;

namespace ImageProcessing.App.Domain.Models.Thresholding
{
    public interface IThreshold
    {
        Bitmap Segment(Bitmap src, byte threshold);
    }
}
