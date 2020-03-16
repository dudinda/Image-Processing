using System.Drawing;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Interface
{
    /// <summary>
    /// Specifies the basic RGB filter.
    /// </summary>
    public interface IRgbFilter
    {
        /// <summary>
        /// Apply filter to the specified bitmap. 
        /// </summary>
        Bitmap Filter(Bitmap bitmap);
    }
}
