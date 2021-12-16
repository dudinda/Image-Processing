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
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Services;
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
                .RegisterSingletonInstance<ICacheServiceWrapper>(
                Substitute.ForPartsOf<CacheServiceWrapper>())
                .RegisterTransientInstance<IColorMatrixServiceWrapper>(
                Substitute.ForPartsOf<ColorMatrixServiceWrapper>())
                .RegisterTransientInstance<IConvolutionServiceWrapper>(
                Substitute.ForPartsOf<ConvolutionServiceWrapper>())
                .RegisterTransientInstance<IBitmapLuminanceServiceWrapper>(
                Substitute.ForPartsOf<BitmapLuminanceServiceWrapper>())
                .RegisterTransientInstance<IRandomVariableServiceWrapper>(
                Substitute.ForPartsOf<RandomVariableServiceWrapper>())
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
                Substitute.ForPartsOf<LoggerServiceWrapper>());
        }
    }
}
