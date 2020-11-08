using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.RgbFilters.Implementation
{
    /// <inheritdoc cref="IRgbFilterService"/>
    internal sealed class RgbFilterService : IRgbFilterService
    {
        /// <inheritdoc/>
        public Bitmap Filter(Bitmap source, IRgbFilter filter)
            => filter.Filter(source);     
    }
}
