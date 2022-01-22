using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Implementation
{
    public sealed class ConvolutionVisitor : IConvolutionVisitor
    {
        private readonly IConvolutionFactory _factory;
        private readonly IConvolutionService _convolution;
        private readonly IBitmapService _service;

        public ConvolutionVisitor(
            IConvolutionFactory factory,
            IConvolutionService convolution,
            IBitmapService service)
        {
            _factory = factory;
            _convolution = convolution;
            _service = service;
        }

        public Bitmap LoGOperator3x3(Bitmap bmp)
             => Operator(Operator(bmp, ConvKernel.GaussianBlur3x3),
                   ConvKernel.LaplacianOperator3x3);

        public Bitmap Operator(Bitmap bmp, ConvKernel filter)
        => _convolution.Convolution(bmp, _factory.Get(filter));

        public Bitmap SobelOverator3x3(Bitmap bmp)
        {
            using (var copy = new Bitmap(bmp))
            {
                var yDerivative = Task.Run(
                    () => Operator(bmp, ConvKernel.SobelOperatorHorizontal3x3)
                );

                var xDerivative = Task.Run(
                    () => Operator(copy, ConvKernel.SobelOperatorVertical3x3)
                );

                return _service.Magnitude(xDerivative.Result, yDerivative.Result);
            }
        }
    }
}
