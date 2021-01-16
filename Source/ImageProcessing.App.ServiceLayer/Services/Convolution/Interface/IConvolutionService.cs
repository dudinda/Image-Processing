using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface
{
    /// <summary>
    /// Provides the kernel-dependent convolution.
    /// </summary>
    public interface IConvolutionService
    {
        /// <summary>
        /// Perform a convolution of the specified <see cref="IConvolutionKernel"/>.
        /// </summary>
        Bitmap Convolution(Bitmap source, IConvolutionKernel filter);
    }
}
