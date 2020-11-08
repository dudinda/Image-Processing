using ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Extensions;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests
{
    internal sealed class MainPresenterTestStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            builder.BindMocksForMainPresenter();
            builder.BindMocksForRgbPresenter();
            builder.BindMocksForConvolutionPresenter();
            builder.BindMocksForDistributionPresenter();
        }
    }
}
