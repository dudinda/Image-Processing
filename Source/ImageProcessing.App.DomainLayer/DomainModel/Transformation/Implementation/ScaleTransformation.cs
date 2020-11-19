using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation
{
    internal sealed class ScaleTransformation : ITransformation
    {
        public Bitmap Transform(Bitmap src, double dx, double dy)
            => new ProximalInterpolation().Resize(src, dx, dy);
    }
}
