using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation
{
    internal sealed class ProximalInterpolation : IScaling
    {
        public Bitmap Resize(Bitmap src, double xScale, double yScale)
            => new ScaleTransformation().Transform(src, xScale, yScale);
        
    }
}
