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
        private readonly IRgbFilterFactory _factory;
        private readonly IRgbFilterService _service;
        private readonly ICacheService<Bitmap> _cache;

        public RgbFilterServiceProvider(
            IRgbFilterFactory factory,
            IRgbFilterService service,
            ICacheService<Bitmap> cache)
        {
            _factory = factory;
            _service = service;
            _cache = cache;
        }

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbFltr filter)
            => _cache.GetOrCreate(filter,
               () => _service.Filter(bmp, _factory.Get(filter))
            );

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbColors filter)
            => _cache.GetOrCreate(filter,
               () => _service.Filter(bmp, _factory.Get(filter))
            );
    }
}
