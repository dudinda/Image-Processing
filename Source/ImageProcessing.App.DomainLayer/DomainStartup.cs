using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Settings.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.DomainLayer
{
    public sealed class DomainStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            builder
                .RegisterSingleton<IAppSettings, AppSettings>()
                .RegisterTransient<IConvolutionFilterFactory, ConvolutionFilterFactory>()
                .RegisterTransient<IMorphologyFactory, MorphologyFactory>()
                .RegisterTransient<IStructuringElementFactory, StructuringElementFactory>()
                .RegisterTransient<IDistributionFactory, DistributionFactory>()
                .RegisterTransient<IRgbFilterFactory, RgbFilterFactory>()
                .RegisterTransient<IScalingFactory, ScalingFactory>()
                .RegisterTransient<IColorMatrixFactory, ColorMatrixFactory>()
                .RegisterTransient<IRecommendationFactory, RecommendationFactory>()
                .RegisterScoped<IColorFactory, ColorFactory>();
        }
    }
}
