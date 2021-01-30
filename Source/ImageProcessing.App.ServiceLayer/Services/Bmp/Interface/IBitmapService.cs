using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Services.Bmp.Interface
{
    /// <summary>
    /// Specifies some operations performed on a <see cref="Bitmap"/>.
    /// </summary>
    public interface IBitmapService
    {
        /// <summary>
        /// The gradient magnitude of an image.
        /// </summary>
        Bitmap Magnitude(Bitmap xDerivative, Bitmap yDerivative);

        /// <summary>
        /// Get the minima value of luma.
        /// </summary>
        byte Min(Bitmap bitmap);

        /// <summary>
        /// Get the maxima value of luma.
        /// </summary>
        byte Max(Bitmap bitmap);

        /// <summary>
        /// Change the range of pixel intensity values.
        /// </summary>
        Bitmap Normalize(Bitmap bitmap);


        /// <summary>
        /// Perform the Fisher–Yates shuffle on a selected bitmap.
        /// </summary>
        Bitmap Shuffle(Bitmap bitmap);
    }
}
