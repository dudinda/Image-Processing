using System.Drawing;

using ImageProcessing.App.Domain.Factories.ColorMatrix.Implementation;
using ImageProcessing.App.Domain.Factories.Convolution.Implementation;
using ImageProcessing.App.Domain.Factories.Distribution.Implementation;
using ImageProcessing.App.Domain.Factories.Recommendation.Implementation;
using ImageProcessing.App.Domain.Factories.Rotation.Implementation;
using ImageProcessing.App.Domain.Factories.Scaling.Implementation;
using ImageProcessing.App.Domain.Factories.Transformation.Implementation;
using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Providers.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.BitmapLuminance.Implementation;
using ImageProcessing.App.Domain.Providers.Convolution;
using ImageProcessing.App.Domain.Providers.Convolution.Implementation;
using ImageProcessing.App.Domain.Providers.Morphology;
using ImageProcessing.App.Domain.Providers.Morphology.Implementation;
using ImageProcessing.App.Domain.Providers.Rgb;
using ImageProcessing.App.Domain.Providers.Rgb.Implementation;
using ImageProcessing.App.Domain.Providers.Rotation;
using ImageProcessing.App.Domain.Providers.Rotation.Implementation;
using ImageProcessing.App.Domain.Providers.Scaling;
using ImageProcessing.App.Domain.Providers.Scaling.Implementation;
using ImageProcessing.App.Domain.Providers.Transformation;
using ImageProcessing.App.Domain.Providers.Transformation.Implementation;
using ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance.Implementation;
using ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution;
using ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution.Implementation;
using ImageProcessing.App.Domain.Providers.Visitors.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.Visitors.BitmapLuminance.Implementation;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution.Implementation;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Implementation;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Bmp;
using ImageProcessing.App.Domain.Services.Bmp.Implementation;
using ImageProcessing.App.Domain.Services.Cache;
using ImageProcessing.App.Domain.Services.Cache.Implementation;
using ImageProcessing.App.Domain.Services.ColorMatrix;
using ImageProcessing.App.Domain.Services.ColorMatrix.Implementation;
using ImageProcessing.App.Domain.Services.Convolution;
using ImageProcessing.App.Domain.Services.Convolution.Implementation;
using ImageProcessing.App.Domain.Services.Distribution;
using ImageProcessing.App.Domain.Services.Distribution.Implementation;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;
using ImageProcessing.App.Domain.Services.Factories.Convolution;
using ImageProcessing.App.Domain.Services.Factories.Distribution;
using ImageProcessing.App.Domain.Services.Factories.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Morphology.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Recommendation;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rgb.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Scaling;
using ImageProcessing.App.Domain.Services.Factories.Transformation;
using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Services.Locker;
using ImageProcessing.App.Domain.Services.LockerService.Operation.Implementation;
using ImageProcessing.App.Domain.Services.Morphology;
using ImageProcessing.App.Domain.Services.Morphology.Implementation;
using ImageProcessing.App.Domain.Services.NonBlockDialog;
using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Domain.Services.StaTask;
using ImageProcessing.App.Domain.Services.UndoRedo;
using ImageProcessing.App.Domain.Services.UndoRedo.Implementation;
using ImageProcessing.App.Domain.Win.Builders.ChartBuilder.Implementation;
using ImageProcessing.App.Domain.Win.Models.Options;
using ImageProcessing.App.Domain.Win.NonBlockDialog.Implementation;
using ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram;
using ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram.Implementation;
using ImageProcessing.App.Domain.Win.Providers.Visitors.Histogram;
using ImageProcessing.App.Domain.Win.Providers.Visitors.Histogram.Implementation;
using ImageProcessing.App.Domain.Win.Services.Builders.ChartSeries;
using ImageProcessing.App.Domain.Win.Services.Histogram;
using ImageProcessing.App.Domain.Win.Services.Histogram.Implementation;
using ImageProcessing.App.Domain.Win.Services.QualityMeasure;
using ImageProcessing.App.Domain.Win.Services.QualityMeasure.Implementation;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Providers;

using MessageLoop.Common.Models.LongRun;
using MessageLoop.Common.Services.LongRun;
using MessageLoop.Common.Services.LongRun.Implementation;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Extensions.Logging;

namespace ImageProcessing.App.Presentation
{
    public sealed class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            builder
                .RegisterSingleton<IConfiguration>((prov) =>
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    return config.Build();
                })
                .RegisterSingleton<SettingsOptions>((prov) =>
                {
                    var config = prov.Resolve<IConfiguration>();
                    return config.GetSection(nameof(SettingsOptions)).Get<SettingsOptions>();
                })
                .RegisterSingleton<IAwaitablePipeline, AwaitablePipeline>()
                .RegisterSingleton<IStaTaskService>((prov) =>
                {
                    var config = prov.Resolve<IConfiguration>();
                    var options = config.GetSection(nameof(StaTaskOptions)).Get<StaTaskOptions>();
                    return new StaTaskService(options);
                })
                .RegisterSingleton<IBitmapCopyService, BitmapCopyService>()
                .RegisterSingleton<ICacheService<Bitmap>>(prov =>
                {
                    var config = prov.Resolve<IConfiguration>();
                    var options = config.GetSection(nameof(MemoryCacheOptions)).Get<MemoryCacheOptions>();
                    return new CacheService<Bitmap>(options);
                })

                .RegisterTransient<IUndoRedoService<Bitmap>>((prov) =>
                {
                    var config = prov.Resolve<IConfiguration>();
                    var options = config.GetSection(nameof(UndoRedoOptions)).Get<UndoRedoOptions>();
                    return new UndoRedoService(options);
                })
                .RegisterSingleton<ILoggerFactory>(prov =>
                {
                    var conf = prov.Resolve<IConfiguration>();
                    var serilog = new LoggerConfiguration()
                    .ReadFrom.Configuration(conf).CreateLogger();
                    return LoggerFactory.Create(builder =>
                    {
                        builder.ClearProviders();
                        builder.AddProvider(new SerilogLoggerProvider(serilog));
                    });
                })
                .RegisterSingleton<ILongRunService<LongRunItem>>((prov) =>
                 {
                     var ctx = new LongRunContext();
                     var factory = prov.Resolve<ILoggerFactory>();
                     var logger = factory.CreateLogger<LongRunService<LongRunItem>>();
                     return new LongRunService<LongRunItem>(logger, ctx);
                 })
                .RegisterTransient<IFileDialogService>(prov =>
                {
                    var config = prov.Resolve<IConfiguration>();
                    var options = config.GetSection(nameof(OpenDialogOptions)).Get<OpenDialogOptions>();
                    return new FileDialogService(options);
                })
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
                .RegisterTransient<ITransformationFactory, TransformationFactory>()
                .RegisterTransient<IConvolutionService, ConvolutionService>()
                .RegisterTransient<IMorphologyService, MorphologyService>()
                .RegisterTransient<IBitmapService, BitmapService>()
                .RegisterTransient<IRandomVariableService, RandomVariableService>()
                .RegisterTransient<IBitmapLuminanceService, BitmapLuminanceService>()
                .RegisterTransient<INonBlockDialogService, NonBlockDialogService>()
                .RegisterTransient<IColorMatrixService, ColorMatrixService>()
                .RegisterTransient<IAsyncOperationLocker, AsyncOperationLocker>()
                .RegisterTransient<IConvolutionProvider, ConvolutionProvider>()
                .RegisterTransient<IMorphologyProvider, MorphologyProvider>()
                .RegisterTransient<IBitmapLuminanceProvider, BitmapLuminanceProvider>()
                .RegisterTransient<IRgbProvider, RgbProvider>()
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
        }
    }
}
