using System.Drawing;

using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.ServiceLayer.Services.RgbFilter.Interface
{
    /// <summary>
    /// Provides a selected <see cref="IRgbFilter"/>
    /// on the specified bitmap.
    /// </summary>
    public interface IRgbFilterService
    {
        /// <summary>
        /// Apply RGB filter to the specified bitmap.
        /// </summary>
        Bitmap Filter(Bitmap source, IRgbFilter filter);
    }
}
