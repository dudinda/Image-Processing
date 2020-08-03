using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterProviders.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;

namespace ImageProcessing.App.ServiceLayer.Facades.MainPresenterProviders.Implementation
{
    public sealed class MainPresenterProvidersFacade : IMainPresenterProvidersFacade
    {
        private readonly IBitmapLuminanceDistributionServiceProvider _lumaProvider;
        private readonly IRgbFilterServiceProvider _rgbProvider;

        public MainPresenterProvidersFacade(
            IBitmapLuminanceDistributionServiceProvider lumaProvider,
            IRgbFilterServiceProvider rgbProvider)
        {
            _lumaProvider = lumaProvider;
            _rgbProvider = rgbProvider;
        }

        /// <inheritdoc cref="IRgbFilterServiceProvider.Apply(Bitmap, RgbFilter)"/>
        public Bitmap Apply(Bitmap bmp, RgbFilter filter)
            => _rgbProvider.Apply(bmp, filter);

        /// <inheritdoc cref="IRgbFilterServiceProvider.Apply(Bitmap, RgbColors)"/>
        public Bitmap Apply(Bitmap bmp, RgbColors filter)
            => _rgbProvider.Apply(bmp, filter);

        /// <inheritdoc cref="IBitmapLuminanceDistributionServiceProvider.GetInfo(Bitmap, RandomVariableInfo)"/>
        public decimal GetInfo(Bitmap bmp, RandomVariableInfo info)
            => _lumaProvider.GetInfo(bmp, info);

        /// <inheritdoc cref="IBitmapLuminanceDistributionServiceProvider.Transform(Bitmap, Distributions, (string, string))"/>
        public Bitmap Transform(
            Bitmap bmp, Distributions distribution, (string, string) parms)
            => _lumaProvider.Transform(bmp, distribution, parms);     
    }
}
