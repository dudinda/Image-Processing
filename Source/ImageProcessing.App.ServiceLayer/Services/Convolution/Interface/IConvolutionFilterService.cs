using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface
{
    /// <summary>
    /// Provides the kernel-dependent convolution.
    /// </summary>
    internal interface IConvolutionFilterService
    {
        /// <summary>
        /// Perform a convolution of the specified <see cref="IConvolutionFilter"/>.
        /// </summary>
        Bitmap Convolution(Bitmap source, IConvolutionFilter filter);
    }
}
