using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.Pipeline.Block.Implementation;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Presentation.ViewModel.Convolution;
using ImageProcessing.Presentation.Views.Convolution;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;

using LightInject;

namespace ImageProcessing.Presentation.Presenters.Convolution
{
    public partial class ConvolutionFilterPresenter : BasePresenter<IConvolutionFilterView, ConvolutionFilterViewModel>
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IConvolutionFilterService _convolutionFilterService;
		private readonly IConvolutionFilterFactory _convolutionFilterFactory;
		private readonly IAsyncLocker _operationLocker;
		public ConvolutionFilterPresenter(IAppController controller,
										  IConvolutionFilterView view,
                                          IAwaitablePipeline pipeline,
										  IConvolutionFilterService convolutionFilterService,
										  IBaseFactory baseFactory,
										  IEventAggregator eventAggregator,

										  [Inject("OperationLocker")]
										  IAsyncLocker operationLocker
            ) : base(controller, view, pipeline)
		{
			_eventAggregator          = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));
			_convolutionFilterService = Requires.IsNotNull(convolutionFilterService, nameof(convolutionFilterService));
			_convolutionFilterFactory = Requires.IsNotNull(baseFactory, nameof(baseFactory)).GetConvolutionFilterFactory();
			_operationLocker          = Requires.IsNotNull(operationLocker, nameof(operationLocker));

			_eventAggregator.Subscribe(this);
		}

		private async Task ApplyConvolutionFilter(ConvolutionFilterEventArgs e)
		{
			try
			{
				var copy = await _operationLocker.LockAsync(() => new Bitmap(ViewModel.Source)).ConfigureAwait(true);

				var block = new PipelineBlock(copy);
				var filter = View.SelectedFilter;

				switch (filter)
				{
					case ConvolutionFilter.SobelOperator3x3:
						block.Add<Bitmap, Bitmap>((bmp) =>
						{
							var yDerivative = Task.Run(() => _convolutionFilterService.Convolution(bmp, new SobelOperatorHorizontal()));
							var xDerivative = Task.Run(() => _convolutionFilterService.Convolution(bmp, new SobelOperatorVertical()));
							return BitmapExtension.Magnitude(xDerivative.Result, yDerivative.Result);
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
			catch(Exception ex)
			{
				View.ShowError();
			}
		}

	}
}
