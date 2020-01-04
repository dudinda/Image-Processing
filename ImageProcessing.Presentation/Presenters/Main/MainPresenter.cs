using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.AppController;
using ImageProcessing.DomainModel.Services.ConvolutionFilter;
using ImageProcessing.DomainModel.Services.Distribution;
using ImageProcessing.DomainModel.Services.RGBFilter;
using ImageProcessing.Factory.Base;
using ImageProcessing.DomainModel.Factory.Filters.Interface;

namespace ImageProcessing.Presentation.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;

        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IDistributionFactory _distributionFactory;
        private readonly IRGBFiltersFactory _rgbFiltersFactory;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IConvolutionFilterService convolutionFilterService,
                             IDistributionService distributionService,
                             IRGBFilterService rgbFilterService,
                             IBaseFactory baseFactory) : base(controller, view)
        {
            _convolutionFilterService = convolutionFilterService;
            _distributionService      = distributionService;
            _rgbFilterService         = rgbFilterService;

            _convolutionFilterFactory = baseFactory.GetConvolutionFilterFactory();
            _distributionFactory      = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory        = baseFactory.GetRGBFilterFactory();

            View.ApplyConvolutionFilter += () => ApplyConvolutionFilter(null);
            View.ApplyRGBFilter += () => ApplyRGBFilter(null);
            View.ApplyHistogramTransformation += () => ApplyHistogramTransformation(null);

        }


        private void ApplyConvolutionFilter(string filterName)
        {
            var filter = _convolutionFilterFactory.GetFilter(filterName);

            View.DstImage = _convolutionFilterService.Convolution(View.SrcImage, filter);
        }


        private void ApplyRGBFilter(string filterName)
        {
            var filter = _rgbFiltersFactory.GetFilter(filterName);

            View.DstImage = _rgbFilterService.Filter(View.SrcImage, filter);
        }


        private void ApplyHistogramTransformation(string filterName)
        {
            var filter = _distributionFactory.GetFilter(filterName);

            View.DstImage = _distributionService.Distribute(View.SrcImage, filter);
        }
    }
}
