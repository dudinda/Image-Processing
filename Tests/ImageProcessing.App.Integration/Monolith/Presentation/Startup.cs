using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Integration.Monolith.Presentation.Presenters;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Providers;

using Microsoft.Extensions.Logging;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.Presentation
{
    public class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new App.Presentation.IntegrationTests.Monolith.Domain.Startup().Build(builder);


            builder
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<MainPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<INonBlockDialogServiceWrapper>(),
                        builder.Resolve<IAwaitablePipelineServiceWrapper>(),
                        builder.Resolve<ILoggerFactory>(),
                        builder.Resolve<IScalingProviderWrapper>(),
                        builder.Resolve<IRotationProviderWrapper>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<MainMenuPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IAwaitablePipelineServiceWrapper>(),
                        builder.Resolve<ILoggerFactory>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<ColorMatrixPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IColorMatrixFactoryWrapper>(),
                        builder.Resolve<ILoggerFactory>(),
                        builder.Resolve<IRgbProviderWrapper>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<ConvolutionPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IConvolutionProviderWrapper>(),
                        builder.Resolve<ILoggerFactory>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<DistributionPresenterWrapper>(
                        builder.Resolve<IBitmapLuminanceProviderWrapper>(),
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IBitmapServiceWrapper>(),
                        builder.Resolve<ILoggerFactory>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<RgbPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IRgbFactoryWrapper>(),
                        builder.Resolve<ILoggerFactory>(),
                        builder.Resolve<IRgbProviderWrapper>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<RotationPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IRotationProviderWrapper>(),
                        builder.Resolve<ILoggerFactory>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<ScalingPresenterWrapper>(
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<IScalingProviderWrapper>(),
                        builder.Resolve<ILoggerFactory>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<SettingsPresenterWrapper>(
                        builder.Resolve<ILoggerFactory>(),
                        builder.Resolve<SettingsOptions>()))
                .RegisterTransient(factory =>
                    Substitute.ForPartsOf<TransformationPresenterWrapper>(
                        builder.Resolve<ITransformationProviderWrapper>(),
                        builder.Resolve<IBitmapCopyServiceWrapper>(),
                        builder.Resolve<ILoggerFactory>()));
        }
    }
}
