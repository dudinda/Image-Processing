using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Morphology.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Histogram.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Histogram.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.RandomVariable.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.FileDialog.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Morphology.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.QualityMeasure.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer
{
    internal class ServiceStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new DomainStartup().Build(builder);

            builder
                .RegisterTransientInstance<IBitmapServiceWrapper>(
                Substitute.ForPartsOf<BitmapServiceWrapper>())
                .RegisterTransientInstance<IMorphologyServiceWrapper>(
                Substitute.ForPartsOf<MorphologyServiceWrapper>())
                .RegisterSingletonInstance<ICacheServiceWrapper>(
                Substitute.ForPartsOf<CacheServiceWrapper>())
                .RegisterTransientInstance<IColorMatrixServiceWrapper>(
                Substitute.ForPartsOf<ColorMatrixServiceWrapper>())
                .RegisterTransientInstance<IConvolutionServiceWrapper>(
                Substitute.ForPartsOf<ConvolutionServiceWrapper>())
                .RegisterTransientInstance<IAsyncOperationLockerWrapper>(
                Substitute.ForPartsOf<AsyncOperationLockerWrapper>())
                .RegisterTransientInstance<IRandomVariableServiceWrapper>(
                Substitute.ForPartsOf<RandomVariableServiceWrapper>())
                .RegisterTransientInstance<IBitmapLuminanceServiceWrapper>(
                Substitute.ForPartsOf<BitmapLuminanceServiceWrapper>(
                    builder.Resolve<IRandomVariableServiceWrapper>()))
                .RegisterTransientInstance<IFileDialogServiceWrapper>(
                Substitute.ForPartsOf<FileDialogServiceWrapper>())
                .RegisterSingletonInstance<IStaTaskServiceWrapper>(
                Substitute.ForPartsOf<StaTaskServiceWrapper>())
                .RegisterTransientInstance<INonBlockDialogServiceWrapper>(
                Substitute.ForPartsOf<NonBlockDialogServiceWrapper>(
                    builder.Resolve<IFileDialogServiceWrapper>(),
                    builder.Resolve<IStaTaskServiceWrapper>()))
                .RegisterTransientInstance<IChartSeriesBuilderWrapper>(
                Substitute.ForPartsOf<ChartSeriesBuilderWrapper>())
                .RegisterSingletonInstance<IAwaitablePipelineServiceWrapper>(
                Substitute.ForPartsOf<AwaitablePipelineServiceWrapper>())
                .RegisterSingletonInstance<ILoggerServiceWrapper>(
                Substitute.ForPartsOf<LoggerServiceWrapper>())
                .RegisterTransientInstance<IQualityMeasureServiceWrapper>(
                Substitute.ForPartsOf<QualityMeasureServiceWrapper>(
                    builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                    builder.Resolve<IChartSeriesBuilderWrapper>()))
                .RegisterTransientInstance<IConvolutionVisitorWrapper>(
                Substitute.ForPartsOf<ConvolutionVisitorWrapper>(
                    builder.Resolve<IConvolutionFactoryWrapper>(),
                    builder.Resolve<IConvolutionServiceWrapper>(),
                    builder.Resolve<IBitmapServiceWrapper>(),
                    builder.Resolve<ICacheServiceWrapper>()))
                .RegisterTransientInstance<IHistogramVisitorWrapper>(
                Substitute.ForPartsOf<HistogramVisitorWrapper>(
                    builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                    builder.Resolve<IChartSeriesBuilderWrapper>()))
                .RegisterTransientInstance<IBitmapLuminanceVisitorWrapper>(
                Substitute.ForPartsOf<BitmapLuminanceVisitorWrapper>(
                    builder.Resolve<IBitmapLuminanceServiceWrapper>()))
                .RegisterTransientInstance<IBitmapLuminanceVisitableFactoryWrapper>(
                Substitute.ForPartsOf<BitmapLuminanceVisitableFactoryWrapper>())
                .RegisterTransientInstance<IConvolutionVisitableFactoryWrapper>(
                Substitute.ForPartsOf<ConvolutionVisitableFactoryWrapper>())
                .RegisterTransientInstance<IHistogramVisitableFactoryWrapper>(
                Substitute.ForPartsOf<HistogramVisitableFactoryWrapper>())
                .RegisterTransientInstance<IBitmapLuminanceProviderWrapper>(
                Substitute.ForPartsOf<BitmapLuminanceProviderWrapper>(
                    builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                    builder.Resolve<IBitmapLuminanceVisitableFactoryWrapper>(),
                    builder.Resolve<IBitmapLuminanceVisitorWrapper>(),
                    builder.Resolve<IDistributionFactoryWrapper>()))
                .RegisterTransientInstance<IConvolutionProviderWrapper>(
                Substitute.ForPartsOf<ConvolutionProviderWrapper>(
                    builder.Resolve<IConvolutionVisitableFactoryWrapper>(),
                    builder.Resolve<IConvolutionVisitorWrapper>()))
                .RegisterTransientInstance<IMorphologyProviderWrapper>(
                Substitute.ForPartsOf<MorphologyProviderWrapper>(
                    builder.Resolve<IMorphologyServiceWrapper>(),
                    builder.Resolve<IMorphologyFactoryWrapper>(),
                    builder.Resolve<ICacheServiceWrapper>(),
                    builder.Resolve<IStructuringElementFactoryWrapper>()))
                .RegisterTransientInstance<IRgbProviderWrapper>(
                Substitute.ForPartsOf<RgbProviderWrapper>(
                    builder.Resolve<IRgbFactoryWrapper>(),
                    builder.Resolve<IColorMatrixServiceWrapper>(),
                    builder.Resolve<IColorMatrixFactoryWrapper>(),
                    builder.Resolve<ICacheServiceWrapper>()))
                .RegisterTransientInstance<IRotationProviderWrapper>(
                Substitute.ForPartsOf<RotationProviderWrapper>(
                    builder.Resolve<IRotationFactoryWrapper>(),
                    builder.Resolve<IAppSettings>()))
                .RegisterTransientInstance <IScalingProviderWrapper>(
                Substitute.ForPartsOf<ScalingProviderWrapper>(
                    builder.Resolve<IScalingFactoryWrapper>(),
                    builder.Resolve<IAppSettings>()))
                .RegisterTransientInstance<ITransformationProviderWrapper>(
                Substitute.ForPartsOf<TransformationProviderWrapper>(
                    builder.Resolve<ITransformationFactoryWrapper>()));
        }
    }
}
