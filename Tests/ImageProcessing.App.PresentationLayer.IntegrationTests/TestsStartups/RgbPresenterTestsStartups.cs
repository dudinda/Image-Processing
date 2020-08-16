using ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Extensions;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsStartups
{
    internal sealed class RgbPresenterTestsStartups : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            builder.BindMocksForMainPresenter();
            builder.BindMocksForRgbPresenter();
        }
    }
}
