using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.CompoundModels.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable;
using ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable.LoGOperator3x3;
using ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable.Operator;
using ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable.SobelOperator3x3;

namespace ImageProcessing.App.ServiceLayer.CompoundModels.VisitableFactory.Convolution.Implementation
{
    internal sealed class ConvolutionVisitableFactory : ICovolutionVisitableFactory
    {
        public IConvolutionVisitable Get(ConvolutionFilter filter)
            => filter
        switch
        {
            ConvolutionFilter.LoGOperator3x3
                => new ConvolutionLoGOperator3x3Visitable(),
            ConvolutionFilter.SobelOperator3x3
                => new ConvolutionSobelOperator3x3Visitable(),

            _ => new ConvolutionOperatorVisitable(filter)
        };
        
    }
}
