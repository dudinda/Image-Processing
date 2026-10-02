using System;
using System.Drawing;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Morphology.Interface;
using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.App.Domain.Services.Morphology.Implementation;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Morphology.Implementation
{
    internal class MorphologyServiceWrapper : IMorphologyServiceWrapper
    {
        private readonly MorphologyService _service
            = new MorphologyService();

        public virtual Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter)
            => _service.ApplyOperator(bmp, kernel, filter);

        public virtual Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter)
            => _service.ApplyOperator(lvalue, rvalue, filter);
    }
}
