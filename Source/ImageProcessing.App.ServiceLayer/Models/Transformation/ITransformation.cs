using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Models.Transformation
{
    public interface ITransformation
    {
        Bitmap Transform(Bitmap src, double x, double y);
    }
}
