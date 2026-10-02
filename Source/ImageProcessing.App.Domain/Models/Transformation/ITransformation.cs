using System.Drawing;

namespace ImageProcessing.App.Domain.Models.Transformation
{
    public interface ITransformation
    {
        Bitmap Transform(Bitmap src, double x, double y);
    }
}
