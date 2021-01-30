using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.StructuringElement.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Implementation;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Presenters.Distribution;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.Presenters.Settings;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Implementation;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.NonBlockDialog.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Morphology;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Implementation;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Implementation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Implementation;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Implementation;
using ImageProcessing.App.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Implementation;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;



namespace ImageProcessing.App.PresentationLayer
{
    public sealed class Startup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            builder
                .RegisterSingleton<IAppSettings, AppSettings>()
                .RegisterTransient<IConvolutionFactory, ConvolutionFactory>()
                .RegisterTransient<IMorphologyFactory, MorphologyFactory>()
                .RegisterTransient<IStructuringElementFactory, StructuringElementFactory>()
                .RegisterTransient<IDistributionFactory, DistributionFactory>()
                .RegisterTransient<IRgbFilterFactory, RgbFilterFactory>()
                .RegisterTransient<IScalingFactory, ScalingFactory>()
                .RegisterTransient<IColorMatrixFactory, ColorMatrixFactory>()
                .RegisterTransient<IRecommendationFactory, RecommendationFactory>()
                .RegisterTransient<IChannelFactory, ChannelFactory>()
                .RegisterTransient<IRotationFactory, RotationFactory>()
                .RegisterTransient<ITransformationFactory, TransformationFactory>();

            builder
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<IStaTaskService, StaTaskService>()
                .RegisterSingleton<ICacheService<Bitmap>, CacheService<Bitmap>>()
                .RegisterTransient<IConvolutionService, ConvolutionService>()
                .RegisterTransient<IMorphologyService, MorphologyService>()
                .RegisterTransient<IBitmapService, BitmapService>()
                .RegisterTransient<IRandomVariableDistributionService, RandomVariableDistributionService>()
                .RegisterTransient<IBitmapLuminanceDistributionService, BitmapLuminanceDistributionService>()
                .RegisterTransient<IFileDialogService, FileDialogService>()
                .RegisterTransient<INonBlockDialogService, NonBlockDialogService>()
                .RegisterTransient<IColorMatrixService, ColorMatrixService>()
                .RegisterTransient<IAsyncOperationLocker, AsyncOperationLocker>()
                .RegisterTransient<IConvolutionServiceProvider, ConvolutionServiceProvider>()
                .RegisterTransient<IMorphologyServiceProvider, MorphologyServiceProvider>()
                .RegisterTransient<IBitmapLuminanceServiceProvider, BitmapLuminanceServiceProvider>()
                .RegisterTransient<IRgbServiceProvider, RgbServiceProvider>()
                .RegisterTransient<IScalingProvider, ScalingProvider>()
                .RegisterTransient<IRotationProvider, RotationProvider>()
                .RegisterTransient<ITransformationProvider, TransformationProvider>()
                .RegisterTransient<IChartSeriesBuilder, ChartSeriesBuilder>()
                .RegisterTransient<IQualityMeasureService, QualityMeasureService>()
                .RegisterTransient<IHistogramService, HistogramService>()
                .RegisterTransient<IBitmapLuminanceVisitableFactory, BitmapLuminanceVisitableFactory>()
                .RegisterTransient<IBitmapLuminanceVisitor, BitmapLuminanceVisitor>()
                .RegisterTransient<IConvolutionVisitor, ConvolutionVisitor>()
                .RegisterTransient<ICovolutionVisitableFactory, ConvolutionVisitableFactory>()
                .RegisterTransient<IHistogramVisitor, HistogramVisitor>()
                .RegisterTransient<IHistogramVisitableFactory, HistogramVisitableFactory>();

            builder
                .RegisterTransient<MainPresenter>()
                .RegisterTransient<RgbPresenter>()
                .RegisterTransient<DistributionPresenter>()
                .RegisterTransient<ConvolutionPresenter>()
                .RegisterTransient<SettingsPresenter>();
        }
    }
}
