using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class ConvolutionPresenter : BasePresenter<IConvolutionView, ConvolutionViewModel>,
          ISubscriber<ApplyConvolutionKernelEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ILoggerService _logger;
        private readonly IConvolutionProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public ConvolutionPresenter(
            IAsyncOperationLocker locker,
            IConvolutionProvider provider,
            ILoggerService logger) 
        {
            _provider = provider;
            _logger = logger;
            _locker = locker;
        }

        /// <inheritdoc cref="ApplyConvolutionKernelEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyConvolutionKernelEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ConvKernel.Unknown)
                {
                    var copy = await _locker.LockOperationAsync(
                        () => new Bitmap(ViewModel.Source)
                    ).ConfigureAwait(true);
               
                    Aggregator.PublishFromAll(publisher,
                        new AttachBlockToRendererEventArgs(
                           block: new PipelineBlock(copy)
                               .Add<Bitmap, Bitmap>(
                                   (bmp) => _provider.ApplyFilter(bmp, filter)
                            )
                        )
                    );
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.ApplyConvolutionFilter);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                if (e.Container == ImageContainer.Source)
                {
                    await _locker.LockOperationAsync(() =>
                    {
                        lock (e.Bmp)
                        {
                            ViewModel.Source = new Bitmap(e.Bmp);
                        }
                    }).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Message);
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public async Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            View.Focus();
        }
    }
}
