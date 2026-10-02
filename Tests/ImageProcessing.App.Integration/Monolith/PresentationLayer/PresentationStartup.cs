using ImageProcessing.App.Integration.Monolith.Presentation.Presenters;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain;
using ImageProcessing.App.Domain.Models.AppSettings;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.Presentation
{
    public class PresentationStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new ServiceStartup().Build(builder);

            builder
                .RegisterTransientInstance(
                Substitute.ForPartsOf<MainPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<INonBlockDialogServiceWrapper>(),
                    builder.Resolve<IAwaitablePipelineServiceWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>(),
                    builder.Resolve<IScalingProviderWrapper>(),
                    builder.Resolve<IRotationProviderWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<ColorMatrixPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IColorMatrixFactoryWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>(),
                    builder.Resolve<IRgbProviderWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<ConvolutionPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IConvolutionProviderWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<DistributionPresenterWrapper>(
                    builder.Resolve<IBitmapLuminanceProviderWrapper>(),
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IBitmapServiceWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<RgbPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IRgbFactoryWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>(),
                    builder.Resolve<IRgbProviderWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<RotationPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IRotationProviderWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<ScalingPresenterWrapper>(
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<IScalingProviderWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<SettingsPresenterWrapper>(
                    builder.Resolve<ILoggerServiceWrapper>(),
                    builder.Resolve<AppSettings>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<TransformationPresenterWrapper>(
                    builder.Resolve<ITransformationProviderWrapper>(),
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()));
        }
    }
}
