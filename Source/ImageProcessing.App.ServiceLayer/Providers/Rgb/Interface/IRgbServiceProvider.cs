using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface
{
    /// <summary>
    /// Provides the <see cref="CommonLayer.Enums.RgbFltr"/> and <see cref="RgbColors"/> implementation.
    /// </summary>
    public interface IRgbServiceProvider
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
