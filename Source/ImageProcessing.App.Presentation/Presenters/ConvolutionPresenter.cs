using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Convolution;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class ConvolutionPresenter : BasePresenter<IConvolutionView, BitmapViewModel>,
          ISubscriber<ApplyConvolutionKernelEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>,
          ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly ILogger<ConvolutionPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IConvolutionProvider _provider;

        public ConvolutionPresenter(
            IBitmapCopyService reference,
            IConvolutionProvider provider,
            ILogger<ConvolutionPresenter> logger) 
        {
            _provider = provider;
            _logger = logger;
            _reference = reference;
        }

        /// <inheritdoc cref="ApplyConvolutionKernelEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyConvolutionKernelEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ConvKernel.Unknown)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

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
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                ViewModel.SelectedArea = e.Area;
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            try
            {
                View.Tooltip(e.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            try
            {
                View.Focus();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                View.Close();
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            try
            {
                View.EnableControls(e.State != MenuBtnState.ImageEmpty);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
