using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Factory.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Implementation.RgbFilter
{
    public sealed class RgbFilterServiceProvider : IRgbFilterServiceProvider
    {
        private readonly IRgbFilterFactory _rgbFilterFactory;
        private readonly IRgbFilterService _rgbFilterService;

        public RgbFilterServiceProvider(IRgbFilterFactory rgbFilterFactory,
                                        IRgbFilterService rgbFilterService)
        {
            _rgbFilterFactory = Requires.IsNotNull(
                rgbFilterFactory, nameof(rgbFilterFactory)
            );
            _rgbFilterService = Requires.IsNotNull(
                rgbFilterService, nameof(rgbFilterService)
            );
        }

        public Bitmap Apply(Bitmap bmp, Common.Enums.RgbFilter filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _rgbFilterService
                      .Filter(bmp,
                          _rgbFilterFactory
                              .GetFilter(filter)
                   );
        }

        public Bitmap Apply(Bitmap bmp, RgbColors filter)
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
