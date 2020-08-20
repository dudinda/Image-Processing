using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution.LoGOperator3x3;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution.Operator;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution.SobelOperator3x3;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Implementation
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
