using System.Drawing;
using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters
{
    /// <summary>
    /// Provides the <see cref="RgbFilter"/> and <see cref="RgbColors"/> implementation.
    /// </summary>
    public interface IRgbFilterServiceProvider
    {
        /// <summary>
        /// Choose the <see cref="RgbFilter"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, RgbFilter filter);

        /// <summary>
        /// Choose the <see cref="RgbColors"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, RgbColors filter);
    }
}
