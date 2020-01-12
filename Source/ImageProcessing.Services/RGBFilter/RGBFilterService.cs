using System;
using System.Drawing;

using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.Services.RGBFilter
{
    public class RGBFilterService : IRGBFilterService
    {
        public Bitmap Filter(Bitmap source, IRGBFilter filter)
        {
            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if(filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return filter.Filter(source);
        }
    }
}
