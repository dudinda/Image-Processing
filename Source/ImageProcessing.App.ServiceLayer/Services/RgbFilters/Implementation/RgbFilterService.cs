using System.Drawing;

using ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.RgbFilters.Implementation
{
    /// <inheritdoc cref="IRgbFilterService"/>
    public sealed class RgbFilterService : IRgbFilterService
    {
        /// <inheritdoc/>
        public Bitmap Filter(Bitmap source, IRgbFilter filter)
            => filter.Filter(source);     
    }
}
