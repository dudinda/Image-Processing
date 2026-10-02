using System.Drawing;

using ImageProcessing.App.ServiceLayer.Models.Convolution;

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
