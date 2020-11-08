using System.Drawing;

namespace ImageProcessing.App.DomainLayer.DomainModel.AffineTransformation.Interface
{
    internal interface ITransformation
    {
        Bitmap Transform(Bitmap src, double x, double y);
    }
}
