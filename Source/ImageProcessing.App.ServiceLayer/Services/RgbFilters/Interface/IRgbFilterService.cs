using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface
{
    /// <summary>
    /// Provides a selected <see cref="IRgbFilter"/>
    /// on the specified bitmap.
    /// </summary>
    internal interface IRgbFilterService
    {
        /// <summary>
        /// Apply RGB filter to the specified bitmap.
        /// </summary>
        Bitmap Filter(Bitmap source, IRgbFilter filter);
    }
}
