using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution
{
    /// <summary>
    /// Provides the <see cref="ConvolutionFilter"/> implementation.
    /// </summary>
    public interface IConvolutionServiceProvider
    {
        /// <summary>
        /// Choose the <see cref="ConvolutionFilter"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap ApplyFilter(Bitmap bmp, ConvolutionFilter filter);
    }
}
