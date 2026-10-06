using System.Drawing;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Services.Cache.Implementation;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;
using ImageProcessing.App.Domain.Services.Factories.Convolution;
using ImageProcessing.App.Domain.Services.Factories.Distribution;
using ImageProcessing.App.Domain.Services.Factories.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Scaling;
using ImageProcessing.App.Domain.Services.Factories.Transformation;
using ImageProcessing.App.Domain.Win.Models.Options;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Morphology.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Scaling.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Histogram.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Histogram.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.Histogram.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.ChartSeries.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.ChartSeries.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Distribution.BitmapLuminance.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Distribution.RandomVariable.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Locker.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Morphology.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.QualityMeasure.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.QualityMeasure.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.StaTask.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.StaTask.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.UndoRedo.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.UndoRedo.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Convolution.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Morphology.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Morphology.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rotation.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rotation.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Services.ColorMatrix.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Services.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Transformation.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Transformation.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Services;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Providers;

using NSubstitute;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain
{
    internal sealed class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new Microkernel.MVP.Startup().Build(builder);
            new ImageProcessing.App.UI.Startup().Build(builder);

            builder
                .RegisterTransient<IColorMatrixFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<ColorMatrixFactoryWrapper>(
                        builder.Resolve<IColorMatrixFactory>()))
                .RegisterTransient<IStructuringElementFactoryWrapper>(provider=>
                    Substitute.ForPartsOf<StructuringElementFactoryWrapper>())
                .RegisterTransient<IConvolutionFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<ConvoltuionFactoryWrapper>(
                        builder.Resolve<IConvolutionFactory>()))
                .RegisterTransient<IDistributionFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<DistributionFactoryWrapper>(
                        builder.Resolve<IDistributionFactory>()))
                .RegisterTransient<IMorphologyFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<MorphologyFactoryWrapper>(
                        builder.Resolve<IMorphologyFactory>()))
                .RegisterTransient<IRgbFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<RgbFactoryWrapper>(
                        builder.Resolve<IRgbFilterFactory>()))
                .RegisterTransient<IRotationFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<RotationFactoryWrapper>(
                        builder.Resolve<IRotationFactory>()))
                .RegisterTransient<IScalingFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<ScalingFactoryWrapper>(
                        builder.Resolve<IScalingFactory>()))
                .RegisterTransient<ITransformationFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<TransformationFactoryWrapper>(
                        builder.Resolve<ITransformationFactory>()));

            builder
               .RegisterTransient<IUndoRedoServiceWrapper>(provider =>
                    Substitute.ForPartsOf<UndoRedoServiceWrapper>(
                        builder.Resolve<UndoRedoOptions>()))
               .RegisterTransient<IBitmapServiceWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapServiceWrapper>())
               .RegisterTransient<IMorphologyServiceWrapper>(provider =>
                    Substitute.ForPartsOf<MorphologyServiceWrapper>())
               .RegisterSingleton<ICacheServiceWrapper>(provider =>
                    Substitute.ForPartsOf<CacheServiceWrapper>(
                        builder.Resolve<CacheService<Bitmap>>()))
               .RegisterTransient<IColorMatrixServiceWrapper>(provider =>
                    Substitute.ForPartsOf<ColorMatrixServiceWrapper>())
               .RegisterTransient<IConvolutionServiceWrapper>(provider =>
                    Substitute.ForPartsOf<ConvolutionServiceWrapper>())
               .RegisterTransient<IAsyncOperationLockerWrapper>(provider =>
                    Substitute.ForPartsOf<AsyncOperationLockerWrapper>())
               .RegisterSingleton<IBitmapCopyServiceWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapCopyServiceWrapper>(
                        builder.Resolve<IAsyncOperationLockerWrapper>()))
               .RegisterTransient<IRandomVariableServiceWrapper>(provider =>
                    Substitute.ForPartsOf<RandomVariableServiceWrapper>())
               .RegisterTransient<IBitmapLuminanceServiceWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapLuminanceServiceWrapper>(
                        builder.Resolve<IRandomVariableServiceWrapper>()))
               .RegisterTransient<IFileDialogServiceWrapper>(provider =>
                    Substitute.ForPartsOf<FileDialogServiceWrapper>())
               .RegisterSingleton<IStaTaskServiceWrapper>(provider =>
                    Substitute.ForPartsOf<StaTaskServiceWrapper>(
                        builder.Resolve<StaTaskOptions>()))
               .RegisterTransient<INonBlockDialogServiceWrapper>(provider =>
                    Substitute.ForPartsOf<NonBlockDialogServiceWrapper>(
                        builder.Resolve<IFileDialogServiceWrapper>(),
                        builder.Resolve<IStaTaskServiceWrapper>()))
               .RegisterTransient<IChartSeriesBuilderWrapper>(provider =>
                    Substitute.ForPartsOf<ChartSeriesBuilderWrapper>())
               .RegisterSingleton<IAwaitablePipelineServiceWrapper>(provider =>
                    Substitute.ForPartsOf<AwaitablePipelineServiceWrapper>())
               .RegisterTransient<IQualityMeasureServiceWrapper>(provider =>
                    Substitute.ForPartsOf<QualityMeasureServiceWrapper>(
                        builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                        builder.Resolve<IChartSeriesBuilderWrapper>()))
               .RegisterTransient<IConvolutionVisitorWrapper>(provider =>
                    Substitute.ForPartsOf<ConvolutionVisitorWrapper>(
                        builder.Resolve<IConvolutionFactoryWrapper>(),
                        builder.Resolve<IConvolutionServiceWrapper>(),
                         builder.Resolve<IBitmapServiceWrapper>()))
               .RegisterTransient<IHistogramVisitorWrapper>(provider =>
                    Substitute.ForPartsOf<HistogramVisitorWrapper>(
                        builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                        builder.Resolve<IChartSeriesBuilderWrapper>()))
               .RegisterTransient<IBitmapLuminanceVisitorWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapLuminanceVisitorWrapper>(
                        builder.Resolve<IBitmapLuminanceServiceWrapper>()))
               .RegisterTransient<IBitmapLuminanceVisitableFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapLuminanceVisitableFactoryWrapper>())
               .RegisterTransient<IConvolutionVisitableFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<ConvolutionVisitableFactoryWrapper>())
               .RegisterTransient<IHistogramVisitableFactoryWrapper>(provider =>
                    Substitute.ForPartsOf<HistogramVisitableFactoryWrapper>())
               .RegisterTransient<IBitmapLuminanceProviderWrapper>(provider =>
                    Substitute.ForPartsOf<BitmapLuminanceProviderWrapper>(
                        builder.Resolve<IBitmapLuminanceServiceWrapper>(),
                         builder.Resolve<IBitmapLuminanceVisitableFactoryWrapper>(),
                         builder.Resolve<IBitmapLuminanceVisitorWrapper>(),
                         builder.Resolve<IDistributionFactoryWrapper>()))
               .RegisterTransient<IConvolutionProviderWrapper>(provider =>
                    Substitute.ForPartsOf<ConvolutionProviderWrapper>(
                        builder.Resolve<IConvolutionVisitableFactoryWrapper>(),
                        builder.Resolve<IConvolutionVisitorWrapper>()))
               .RegisterTransient<IMorphologyProviderWrapper>(provider =>
                    Substitute.ForPartsOf<MorphologyProviderWrapper>(
                        builder.Resolve<IMorphologyServiceWrapper>(),
                        builder.Resolve<IMorphologyFactoryWrapper>(),
                        builder.Resolve<ICacheServiceWrapper>(),
                        builder.Resolve<IStructuringElementFactoryWrapper>()))
               .RegisterTransient<IRgbProviderWrapper>(provider =>
                    Substitute.ForPartsOf<RgbProviderWrapper>(
                        builder.Resolve<IRgbFactoryWrapper>(),
                        builder.Resolve<IColorMatrixServiceWrapper>(),
                        builder.Resolve<IColorMatrixFactoryWrapper>(),
                        builder.Resolve<ICacheServiceWrapper>()))
               .RegisterTransient<IRotationProviderWrapper>(provider =>
                    Substitute.ForPartsOf<RotationProviderWrapper>(
                        builder.Resolve<IRotationFactoryWrapper>(),
                        builder.Resolve<AppOptions>()))
               .RegisterTransient<IScalingProviderWrapper>(provider =>
                    Substitute.ForPartsOf<ScalingProviderWrapper>(
                        builder.Resolve<IScalingFactoryWrapper>(),
                        builder.Resolve<AppOptions>()))
               .RegisterTransient<ITransformationProviderWrapper>(provider =>
                    Substitute.ForPartsOf<TransformationProviderWrapper>(
                        builder.Resolve<ITransformationFactoryWrapper>()));
        }
    }
}
