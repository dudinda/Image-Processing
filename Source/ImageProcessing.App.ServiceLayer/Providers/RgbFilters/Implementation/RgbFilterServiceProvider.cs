using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.RgbFilters
{
    /// <inheritdoc cref="IRgbFilterServiceProvider"/>
    internal sealed class RgbFilterServiceProvider : IRgbFilterServiceProvider
    {
        private readonly IRgbFilterFactory _rgbFilterFactory;
        private readonly IRgbFilterService _rgbFilterService;
        private readonly ICacheService<Bitmap> _cache;

        public RgbFilterServiceProvider(IRgbFilterFactory rgbFilterFactory,
                                        IRgbFilterService rgbFilterService,
                                        ICacheService<Bitmap> cache)
        {
            _rgbFilterFactory = rgbFilterFactory;
            _rgbFilterService = rgbFilterService;
            _cache = cache;
        }

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbFltr filter)
            => _cache.GetOrCreate(filter,
               () => _rgbFilterService
                   .Filter(bmp,
                       _rgbFilterFactory
                           .Get(filter)
               )
           );

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbColors filter)
            => _cache.GetOrCreate(filter,
               () => _rgbFilterService
                   .Filter(bmp,
                       _rgbFilterFactory
                           .Get(filter)
               )
           );
    }
}
