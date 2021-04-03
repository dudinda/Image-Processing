using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution.LoGOperator3x3
{
    internal sealed class ConvolutionLoGOperator3x3Visitable : IConvolutionVisitable
    {
        private IConvolutionVisitor? _visitor;

        public IConvolutionVisitable Accept(IConvolutionVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public Bitmap Filter(Bitmap bmp)
            => _visitor?.LoGOperator3x3(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));
    }
}
