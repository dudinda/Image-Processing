using System;
using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution;

namespace ImageProcessing.App.Domain.Providers.Visitable.Convolution.Implementation
{
    internal sealed class ConvolutionOperatorVisitable : IConvolutionVisitable
    {
        private readonly ConvKernel _filter;

        private IConvolutionVisitor? _visitor;

        public ConvolutionOperatorVisitable(ConvKernel filter)
        {
            _filter = filter;
        }

        public IConvolutionVisitable Accept(IConvolutionVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public Bitmap Filter(Bitmap bmp)
            => _visitor?.Operator(bmp, _filter)
                ?? throw new ArgumentNullException(nameof(_visitor));    
    }
}
