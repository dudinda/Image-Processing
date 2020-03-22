using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Factory.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter;
using ImageProcessing.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Implementation.RgbFilter
{
    public sealed class RgbFilterServiceProvider : IRgbFilterServiceProvider
    {
        private readonly IRgbFilterFactory _rgbFilterFactory;
        private readonly IRgbFilterService _rgbFilterService;
        private readonly ICacheService<Bitmap> _cache;

        public RgbFilterServiceProvider(IRgbFilterFactory rgbFilterFactory,
                                        IRgbFilterService rgbFilterService,
                                        ICacheService<Bitmap> cache)
        {
            _rgbFilterFactory = Requires.IsNotNull(
                rgbFilterFactory, nameof(rgbFilterFactory));
            _rgbFilterService = Requires.IsNotNull(
                rgbFilterService, nameof(rgbFilterService));
            _cache = Requires.IsNotNull(
                cache, nameof(cache));
        }

        public Bitmap Apply(Bitmap bmp, Common.Enums.RgbFilter filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _cache.GetOrCreate(filter,
                () =>
                _rgbFilterService
                    .Filter(bmp,
                        _rgbFilterFactory
                            .Get(filter)
                )
            ); 
        }

        public Bitmap Apply(Bitmap bmp, RgbColors filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _cache.GetOrCreate(filter,
                () =>
                _rgbFilterService
                    .Filter(bmp,
                        _rgbFilterFactory
                            .GetColorFilter(filter)
                )
            );
        }
    }
}
