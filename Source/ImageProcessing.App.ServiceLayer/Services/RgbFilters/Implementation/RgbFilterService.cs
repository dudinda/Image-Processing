using System.Drawing;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.RgbFilters.Implementation
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
