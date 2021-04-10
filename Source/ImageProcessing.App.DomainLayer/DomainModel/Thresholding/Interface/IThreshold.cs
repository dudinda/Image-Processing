using System.Drawing;

namespace ImageProcessing.App.DomainLayer.DomainModel.Thresholding.Interface
{
    public interface IThreshold
    {
        Bitmap Segment(Bitmap src, byte threshold);
    }
}
