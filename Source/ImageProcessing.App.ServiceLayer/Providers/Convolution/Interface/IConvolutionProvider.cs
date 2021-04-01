using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution
{
    /// <summary>
    /// Provides the <see cref="ConvKernel"/> implementation.
    /// </summary>
    public interface IConvolutionProvider
    {
        /// <summary>
        /// Choose the <see cref="ConvKernel"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap ApplyFilter(Bitmap bmp, ConvKernel filter);
    }
}
