using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.AffineTransformation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.AffineTransformation.Implementation
{
    internal sealed class ScaleTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double x, double y)
            => new ProximalInterpolation().Resize(src, x, y);
    }
}
