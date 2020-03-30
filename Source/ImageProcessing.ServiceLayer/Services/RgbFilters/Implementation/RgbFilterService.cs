using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.ServiceLayer.Services.RgbFilters.Implementation
{
    /// <inheritdoc cref="IRgbFilterService"/>
    public sealed class RgbFilterService : IRgbFilterService
    {
        /// <inheritdoc/>
        public Bitmap Filter(Bitmap source, IRgbFilter filter)
        {
            Requires.IsNotNull(source, nameof(source));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(source);
        }
    }
}