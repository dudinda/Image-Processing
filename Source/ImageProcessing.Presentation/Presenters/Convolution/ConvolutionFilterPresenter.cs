using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Pipeline.Block.Implementation;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.DomainModel.EventArgs;
using ImageProcessing.DomainModel.EventArgs.Convolution;
using ImageProcessing.Presentation.ViewModel.Convolution;
using ImageProcessing.Presentation.Views.Convolution;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.Presentation.Presenters.Convolution
{
    public partial class ConvolutionFilterPresenter : BasePresenter<IConvolutionFilterView, ConvolutionFilterViewModel> 
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IConvolutionFilterFactory _convolutionFilterFactory;

        public ConvolutionFilterPresenter(IAppController controller,
                                          IConvolutionFilterView view,
                                          IConvolutionFilterService convolutionFilterService,
                                          IBaseFactory baseFactory,
                                          IEventAggregator eventAggregator) : base(controller, view)
        {
            

            _eventAggregator          = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));
            _convolutionFilterService = Requires.IsNotNull(convolutionFilterService, nameof(convolutionFilterService));
            _convolutionFilterFactory = Requires.IsNotNull(baseFactory, nameof(baseFactory)).GetConvolutionFilterFactory();

            _eventAggregator.Subscribe(this);
        }

        public async Task ApplyConvolutionFilter(ConvolutionFilterEventArgs e)
        {
            try
            {
                var block = new PipelineBlock<Bitmap>(ViewModel.Source);
                var filter = View.SelectedFilter;

                switch(filter)
                {
                    case ConvolutionFilter.SobelOperator3x3:
                        block.Add<Bitmap, Bitmap>((bmp) =>
                        {
                            var yDerivative = _convolutionFilterService.Convolution(bmp, new SobelOperatorHorizontal());
                            var xDerivative = _convolutionFilterService.Convolution(bmp, new SobelOperatorVertical());
                            return BitmapExtension.Magnitude(xDerivative, yDerivative);
                        });
                        break;

                    default:
                        block.Add<Bitmap, Bitmap>((bmp) =>
                        {
                            return _convolutionFilterService.Convolution(bmp, _convolutionFilterFactory.GetFilter(filter));
                        });
                        break;

                }

                _eventAggregator.Publish(new ApplyConvolutionFilterEventArgs(block));

            }
            catch
            {
                View.ShowError();
            }
        }

    }
}
