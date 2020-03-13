using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.RGBFilters;
using ImageProcessing.ServiceLayer.Services.RGBFilterService.Interface;

namespace ImageProcessing.ServiceLayer.Services.RGBFilterService.Implementation
{
    public class RGBFilterService : IRGBFilterService
    {
        public Bitmap Filter(Bitmap source, IRGBFilter filter)
        {
            Requires.IsNotNull(source, nameof(source));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(source);
        }
    }
}
