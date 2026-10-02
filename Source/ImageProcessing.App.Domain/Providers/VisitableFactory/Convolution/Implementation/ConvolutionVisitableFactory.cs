using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution.LoGOperator3x3;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution.Operator;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution.SobelOperator3x3;

namespace ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution.Implementation
{
    public sealed class ConvolutionVisitableFactory : ICovolutionVisitableFactory
    {
        public IConvolutionVisitable Get(ConvKernel filter)
            => filter
        switch
        {
            ConvKernel.LoGOperator3x3
                => new ConvolutionLoGOperator3x3Visitable(),
            ConvKernel.SobelOperator3x3
                => new ConvolutionSobelOperator3x3Visitable(),

            _   => new ConvolutionOperatorVisitable(filter)
        };
        
    }
}
