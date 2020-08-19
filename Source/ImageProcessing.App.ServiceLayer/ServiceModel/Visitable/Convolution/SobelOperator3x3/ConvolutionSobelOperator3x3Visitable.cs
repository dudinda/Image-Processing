using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable.SobelOperator3x3
{
    internal sealed class ConvolutionSobelOperator3x3Visitable : IConvolutionVisitable
    {
        private IConvolutionVisitor _visitor = null!;

        public IConvolutionVisitable Accept(IConvolutionVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public Bitmap Filter(Bitmap bmp)
            => _visitor?.SobelOverator3x3(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));
      
    }
}
