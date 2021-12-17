using System;
using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Morphology.Implementation
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
