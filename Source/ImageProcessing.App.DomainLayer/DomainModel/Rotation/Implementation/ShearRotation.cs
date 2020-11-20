using System;
using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation
{
    public sealed class ShearRotation : IRotation
    {
        public Bitmap Rotate(Bitmap bmp, double rad)
        {
            var shear = new ShearTransformation();

            // A(alpha)A(beta)A(gamma) = S(phi)
            // where A is a shear matrix and S is a rotation matrix
            // alpha = gamma = -tan(phi/2), beta = sin(phi)
            var first  = shear.Transform(bmp, -Math.Tan(rad / 2), 0);
            var second = shear.Transform(first, 0, Math.Sin(rad));

            if (Math.Abs(rad) < 0.05) { return second; }

            return shear.Transform(second, -Math.Tan(rad / 2), 0);
        }
            
        
    }
}
