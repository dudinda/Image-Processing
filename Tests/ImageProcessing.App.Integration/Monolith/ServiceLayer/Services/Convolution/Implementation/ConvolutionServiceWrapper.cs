using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Convolution.Implementation
{
    internal class ConvolutionServiceWrapper : IConvolutionServiceWrapper
    {
        private readonly ConvolutionService _service
            = new ConvolutionService();

        public virtual Bitmap Convolution(Bitmap source, IConvolutionKernel filter)
            => _service.Convolution(source, filter);
    }
}
