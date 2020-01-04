using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.AppController;
using ImageProcessing.DomainModel.Services.ConvolutionFilter;
using ImageProcessing.DomainModel.Services.Distribution;
using ImageProcessing.DomainModel.Services.RGBFilter;

namespace ImageProcessing.Presentation.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IConvolutionFilterService convolutionFilterService,
                             IDistributionService distributionService,
                             IRGBFilterService rgbFilterService) : base(controller, view)
        {
            _convolutionFilterService = convolutionFilterService;
            _distributionService      = distributionService;
            _rgbFilterService         = rgbFilterService;
        }
    }
}
