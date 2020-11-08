using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Presenters.Distribution;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.Presenters.Settings;
using ImageProcessing.App.ServiceLayer;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.PresentationLayer
{
    public sealed class PresentationStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            new ServiceStartup().Build(builder);

            builder
                .RegisterTransient<MainPresenter>()
                .RegisterTransient<RgbPresenter>()
                .RegisterTransient<DistributionPresenter>()
                .RegisterTransient<ConvolutionPresenter>()
                .RegisterTransient<SettingsPresenter>();
        }
    }
}
