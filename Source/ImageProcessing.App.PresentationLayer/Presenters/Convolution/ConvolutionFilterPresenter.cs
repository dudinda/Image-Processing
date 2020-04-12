using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.Framework.Core.Controller.Interface;
using ImageProcessing.App.DomainModel.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters.Convolution
{
    internal sealed partial class ConvolutionFilterPresenter
        : BasePresenter<IConvolutionFilterView, ConvolutionFilterViewModel>
	{
		private readonly IConvolutionServiceProvider _convolutionProvider;
		private readonly IAsyncOperationLocker _operationLocker;

        public ConvolutionFilterPresenter(IAppController controller,
                                          IConvolutionFilterView view,
                                          IAwaitablePipeline pipeline,
                                          IEventAggregator eventAggregator,
                                          IConvolutionServiceProvider convolutionFilterServiceProvider,
                                          IAsyncOperationLocker operationLocker
            ) : base(controller, view, pipeline, eventAggregator)
        {
            _convolutionProvider = Requires.IsNotNull(
                convolutionFilterServiceProvider, nameof(convolutionFilterServiceProvider));
            _operationLocker = Requires.IsNotNull(
                operationLocker, nameof(operationLocker));

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

                var filter = View.SelectedFilter;

                var block = new PipelineBlock(copy)
                    .Add<Bitmap, Bitmap>(
                        (bmp) => _convolutionProvider
                            .ApplyFilter(bmp, filter)
                    );

                EventAggregator.Publish(
                    new ApplyConvolutionFilterEventArgs(
                       block
                    )
                );
			}
			catch(Exception ex)
			{
				View.ShowError("Error while applying a convolution filter.");
			}
		}

        private async Task ShowTooltipOnError(ShowTooltipOnErrorEventArgs e)
            => View.ShowError(e.Error);
	}
}
