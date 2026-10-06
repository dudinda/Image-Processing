using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Providers.Scaling;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.ScalingArgs;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class ScalingPresenter : BasePresenter<IScalingView, BitmapViewModel>,
        ISubscriber<ScaleEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>

    {
        private readonly ILogger<ScalingPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IScalingProvider _provider;

        public ScalingPresenter(
            IBitmapCopyService reference,
            IScalingProvider provider,
            ILogger<ScalingPresenter> logger)
        {
            _reference = reference;
            _provider = provider;
            _logger = logger;
        }

        public async Task OnEventHandler(object publisher, ScaleEventArgs e)
        {
            try
            {
                var (xStr, yStr) = View.Parameters;

                var x = Convert.ToDouble(xStr);
                var y = Convert.ToDouble(yStr);

                var copy = await _reference.GetCopy().ConfigureAwait(true);

                var method = View.Dropdown;

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Scale(bmp, x, y, method))
                    )
                 );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyTransformation);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            try
            {
                View.Tooltip(e.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
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

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            try
            {
                View.Focus();
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
