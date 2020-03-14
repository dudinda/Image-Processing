using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.Core.ServiceLayer.Providers.RgbFilter;
using ImageProcessing.ServiceLayer.Services.RGBFilterService.Interface;

namespace ImageProcessing.ServiceLayer.Providers.RgbFilter
{
    public class RgbFilterServiceProvider : IRgbFilterServiceProvider
    {
        private readonly IRGBFiltersFactory _rgbFilterFactory;
        private readonly IRGBFilterService _rgbFilterService;

        public RgbFilterServiceProvider(IRGBFiltersFactory rgbFilterFactory,
                                        IRGBFilterService rgbFilterService)
        {
            _rgbFilterFactory = Requires.IsNotNull(
                rgbFilterFactory, nameof(rgbFilterFactory)
            );

            _rgbFilterService = Requires.IsNotNull(
                rgbFilterService, nameof(rgbFilterService)
            );
        }

        public Bitmap Apply(Bitmap bmp, RGBFilter filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _rgbFilterService
                      .Filter(bmp,
                          _rgbFilterFactory
                              .GetFilter(filter)
                   );
        }

        public Bitmap Apply(Bitmap bmp, RGBColors filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _rgbFilterService
                      .Filter(bmp,
                          _rgbFilterFactory
                              .GetColorFilter(filter)
                   );
        }
    }
}
