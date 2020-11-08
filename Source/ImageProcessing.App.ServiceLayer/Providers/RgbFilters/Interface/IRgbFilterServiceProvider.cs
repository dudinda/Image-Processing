using System.Drawing;
using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters
{
    /// <summary>
    /// Provides the <see cref="CommonLayer.Enums.RgbFltr"/> and <see cref="RgbColors"/> implementation.
    /// </summary>
    public interface IRgbFilterServiceProvider
    {
        /// <summary>
        /// Choose the <see cref="CommonLayer.Enums.RgbFltr"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, CommonLayer.Enums.RgbFltr filter);

        /// <summary>
        /// Choose the <see cref="RgbColors"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, RgbColors filter);
    }
}
