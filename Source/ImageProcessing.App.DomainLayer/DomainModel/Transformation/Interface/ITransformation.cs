using System.Drawing;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface
{
    public interface ITransformation
    {
        Bitmap Transform(Bitmap src, double dx, double dy);
    }
}
