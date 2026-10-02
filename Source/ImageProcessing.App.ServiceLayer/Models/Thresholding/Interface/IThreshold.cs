using System.Drawing;

namespace ImageProcessing.App.DomainLayer.Models.Thresholding.Interface
{
    public interface IThreshold
    {
        Bitmap Segment(Bitmap src, byte threshold);
    }
}
