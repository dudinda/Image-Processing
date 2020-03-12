using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Pipeline;
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
		private readonly IConvolutionFilterService _convolutionFilterService;
		private readonly IConvolutionFilterFactory _convolutionFilterFactory;
		private readonly IAsyncLocker _operationLocker;
		public ConvolutionFilterPresenter(IAppController controller,
										  IConvolutionFilterView view,
                                          IAwaitablePipeline pipeline,
                                          IEventAggregator eventAggregator,
										  IConvolutionFilterService convolutionFilterService,
										  IBaseFactory baseFactory,

										  [Inject("OperationLocker")]
										  IAsyncLocker operationLocker
            ) : base(controller, view, pipeline, eventAggregator)
		{
			_convolutionFilterService = Requires.IsNotNull(convolutionFilterService, nameof(convolutionFilterService));
			_convolutionFilterFactory = Requires.IsNotNull(baseFactory, nameof(baseFactory)).GetConvolutionFilterFactory();
			_operationLocker          = Requires.IsNotNull(operationLocker, nameof(operationLocker));

			EventAggregator.Subscribe(this);
		}

		private async Task ApplyConvolutionFilter(ConvolutionFilterEventArgs e)
		{
			try
			{
				var copy = await _operationLocker
                    .LockAsync(
                        () => new Bitmap(ViewModel.Source)
                     ).ConfigureAwait(true);

                EventAggregator.Publish(
                    new ApplyConvolutionFilterEventArgs(GetBlock())
                );

                IPipelineBlock GetBlock()
                {
                    var block = new PipelineBlock(copy);

                    switch (View.SelectedFilter)
                    {
                        case ConvolutionFilter.BoxBlur3x3:
                        case ConvolutionFilter.BoxBlur5x5:
                        case ConvolutionFilter.EmbossOperator3x3:
                        case ConvolutionFilter.GaussianBlur3x3:
                        case ConvolutionFilter.GaussianBlur5x5:
                        case ConvolutionFilter.GaussianOperator3x3:
                        case ConvolutionFilter.GaussianOperator5x5:
                        case ConvolutionFilter.LaplacianOperator3x3:
                        case ConvolutionFilter.LaplacianOperator5x5:
                        case ConvolutionFilter.MotionBlur9x9:
                        case ConvolutionFilter.SharpenOperator3x3:
                        case ConvolutionFilter.SobelOperatorHorizontal3x3:
                        case ConvolutionFilter.SobelOperatorVertical3x3:

                            return block.Add<Bitmap, Bitmap>((bmp) =>
                             _convolutionFilterService
                                 .Convolution(bmp,
                                     _convolutionFilterFactory
                                         .GetFilter(filter)
                                  )
                             );

                        case ConvolutionFilter.SobelOperator3x3:

                            return block.Add<Bitmap, Bitmap>((bmp) =>
                            {
                                var yDerivative = Task.Run(
                                    () => _convolutionFilterService
                                       .Convolution(bmp,
                                          _convolutionFilterFactory
                                             .GetFilter(ConvolutionFilter.SobelOperatorHorizontal3x3)
                                        )
                                );

                                var xDerivative = Task.Run(
                                    () => _convolutionFilterService
                                        .Convolution(bmp,
                                            _convolutionFilterFactory
                                                .GetFilter(ConvolutionFilter.SobelOperatorVertical3x3)
                                         )
                                );

                                return BitmapExtension.Magnitude(xDerivative.Result, yDerivative.Result);
                            });

                        case ConvolutionFilter.LoGOperator3x3:

                            return block.Add<Bitmap, Bitmap>((bmp) =>
                            {
                                var gaussian = _convolutionFilterService
                                    .Convolution(bmp,
                                        _convolutionFilterFactory
                                            .GetFilter(ConvolutionFilter.GaussianOperator3x3)
                                    );

                                return _convolutionFilterService
                                    .Convolution(gaussian,
                                        _convolutionFilterFactory
                                            .GetFilter(ConvolutionFilter.LaplacianOperator3x3)
                                    );
                            });

                        default: throw new NotImplementedException(nameof(filter));
                    }
                };			
			}
			catch(Exception ex)
			{
				View.ShowError();
			}
		}

	}
}
