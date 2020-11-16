using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    internal sealed class ScaleTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double x, double y)
            => new ProximalInterpolation().Resize(src, x, y);
    }
}
