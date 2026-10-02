using System;
using System.Drawing;

using ImageProcessing.App.Domain.Providers.Visitable.Convolution;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution;

namespace ImageProcessing.App.Domain.Providers.Visitable.Convolution.SobelOperator3x3
{
    internal sealed class ConvolutionSobelOperator3x3Visitable : IConvolutionVisitable
    {
        private IConvolutionVisitor? _visitor;

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
