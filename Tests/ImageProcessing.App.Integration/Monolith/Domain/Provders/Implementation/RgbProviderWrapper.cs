using System.Drawing;

using ImageProcessing.App.Domain.Code.Collections;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Rgb.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Services.ColorMatrix.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Implementation
{
    internal class RgbProviderWrapper : IRgbProviderWrapper
    {
        private readonly RgbProvider _provider;

        public IRgbFactoryWrapper RgbFactory { get; }
        public IColorMatrixServiceWrapper ColorMatrixService { get; }
        public IColorMatrixFactoryWrapper ColorMatrixFactory { get; }
        public ICacheServiceWrapper CacheService { get; }

        public RgbProviderWrapper(
            IRgbFactoryWrapper rgb,
            IColorMatrixServiceWrapper service,
            IColorMatrixFactoryWrapper matrix,
            ICacheServiceWrapper cache)
        {
            RgbFactory = rgb;
            ColorMatrixService = service;
            ColorMatrixFactory = matrix;
            CacheService = cache;

            _provider = new RgbProvider(rgb, service, matrix, cache);
        }

        public virtual Bitmap Apply(Bitmap bmp, RgbFltr filter)
            => _provider.Apply(bmp, filter);

        public virtual Bitmap Apply(Bitmap bmp, RgbChannels filter)
            => _provider.Apply(bmp, filter);

        public virtual Bitmap Apply(Bitmap bmp, ClrMatrix matrix)
            => _provider.Apply(bmp, matrix);

        public virtual Bitmap Apply(Bitmap bmp, ReadOnly2DArray<double> matrix)
            => _provider.Apply(bmp, matrix);
    }
}
