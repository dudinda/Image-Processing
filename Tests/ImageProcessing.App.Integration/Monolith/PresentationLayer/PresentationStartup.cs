using ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
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
                    builder.Resolve<IAppSettings>()))
                .RegisterTransientInstance(
                Substitute.ForPartsOf<TransformationPresenterWrapper>(
                    builder.Resolve<ITransformationProviderWrapper>(),
                    builder.Resolve<IBitmapCopyServiceWrapper>(),
                    builder.Resolve<ILoggerServiceWrapper>()));
        }
    }
}
