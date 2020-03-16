using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Interface;

namespace ImageProcessing.ServiceLayer.Services.RgbFilter.Implementation
{
    public sealed class RgbFilterService : IRgbFilterService
    {
        public Bitmap Filter(Bitmap source, IRgbFilter filter)
        {
            Requires.IsNotNull(source, nameof(source));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(source);
        }
    }
}
