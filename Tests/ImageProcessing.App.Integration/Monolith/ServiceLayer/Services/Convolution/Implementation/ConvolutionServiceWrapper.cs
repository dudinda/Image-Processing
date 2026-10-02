using System.Drawing;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Convolution.Interface;
using ImageProcessing.App.Domain.Models.Convolution;
using ImageProcessing.App.Domain.Services.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Convolution.Implementation
{
    internal class ConvolutionServiceWrapper : IConvolutionServiceWrapper
    {
        private readonly ConvolutionService _service
            = new ConvolutionService();

        public virtual Bitmap Convolution(Bitmap source, IConvolutionKernel filter)
            => _service.Convolution(source, filter);
    }
}
