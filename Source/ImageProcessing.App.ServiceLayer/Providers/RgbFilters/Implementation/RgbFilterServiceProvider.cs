using System.Drawing;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.RgbFilters
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

        public Bitmap Apply(Bitmap bmp, RgbFilter filter)
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
                            .Get(filter)
                )
            );
        }
    }
}
