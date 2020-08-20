using System;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution.Operator
{
    internal sealed class ConvolutionOperatorVisitable : IConvolutionVisitable
    {
        private readonly ConvolutionFilter _filter;

        private IConvolutionVisitor _visitor = null!;

        public ConvolutionOperatorVisitable(ConvolutionFilter filter)
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
