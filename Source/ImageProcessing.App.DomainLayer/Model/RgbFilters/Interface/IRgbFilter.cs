using System.Drawing;

namespace ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface
{
    /// <summary>
    /// Specifies a basic RGB filter.
    /// </summary>
    public interface IRgbFilter
    {
        /// <summary>
        /// Apply a filter to the specified bitmap. 
        /// </summary>
        Bitmap Filter(Bitmap bitmap);
    }
}
