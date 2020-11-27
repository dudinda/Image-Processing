using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface
{
    /// <summary>
    /// Provides the <see cref="RgbFltr"/> and <see cref="RgbChannels"/> implementation.
    /// </summary>
    public interface IRgbServiceProvider
    {
        /// <summary>
        /// Choose the <see cref="RgbFltr"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, RgbFltr filter);

        /// <summary>
        /// Choose the <see cref="RgbChannels"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, RgbChannels filter);

        /// <summary>
        /// Choose the <see cref="ClrMatrix"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, ClrMatrix matrix);


        /// <summary>
        /// Apply a custom color matrix to the
        /// specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, ReadOnly2DArray<double> matrix);
    }
}
