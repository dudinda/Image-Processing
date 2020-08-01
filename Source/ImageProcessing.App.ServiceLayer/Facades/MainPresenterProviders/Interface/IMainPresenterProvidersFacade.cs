using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;

namespace ImageProcessing.App.ServiceLayer.Facades.MainPresenterProviders.Interface
{
    public interface IMainPresenterProvidersFacade
        : IBitmapLuminanceDistributionServiceProvider,
          IRgbFilterServiceProvider
    {

    }
}
