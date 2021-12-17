using System;
using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Implementation;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Implementation
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
