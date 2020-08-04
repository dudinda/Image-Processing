using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Convolution
{
    internal sealed partial class ConvolutionFilterPresenter
        : BasePresenter<IConvolutionView, ConvolutionFilterViewModel>,
          ISubscriber<ApplyConvolutionFilterEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {
		private readonly IConvolutionServiceProvider _convolutionProvider;
		private readonly IAsyncOperationLocker _operationLocker;

        public ConvolutionFilterPresenter(
            IAppController controller,
            IConvolutionServiceProvider convolutionServiceProvider,
            IAsyncOperationLocker operationLocker) : base(controller)
        {
            _convolutionProvider = convolutionServiceProvider;
            _operationLocker = operationLocker;
        }

		public async Task OnEventHandler(object publisher, ApplyConvolutionFilterEventArgs e)
		{
			try
			{
                var filter = View.Dropdown;

                if (filter != ConvolutionFilter.Unknown)
                {
                    var copy = await _operationLocker
                        .LockOperationAsync(
                            () => new Bitmap(ViewModel.Source)
                         ).ConfigureAwait(true);

                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>(
                            (bmp) => _convolutionProvider
                                .ApplyFilter(bmp, filter)
                        );

                    Controller.Aggregator.PublishFrom(
                        e.Publisher,
                        new AttachToRendererEventArgs(
                           block
                        )
                    );
                }
			}
			catch(Exception ex)
			{
				View.Tooltip(Errors.ApplyConvolutionFilter);
			}
		}

        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);

            return Task.CompletedTask;
        }         
	}
}
