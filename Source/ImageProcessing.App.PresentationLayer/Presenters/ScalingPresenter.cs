using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class ScalingPresenter : BasePresenter<IScalingView, BitmapViewModel>,
        ISubscriber<ScaleEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>

    {
        private readonly ILoggerService _logger;
        private readonly IScalingProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public ScalingPresenter(
            IAsyncOperationLocker locker,
            IScalingProvider provider,
            ILoggerService logger)
        {
            _provider = provider;
            _logger = logger;
            _locker = locker;
        }

        public async Task OnEventHandler(object publisher, ScaleEventArgs e)
        {
            try
            {
                var (xStr, yStr) = View.Parameters;

                var x = Convert.ToDouble(xStr);
                var y = Convert.ToDouble(yStr);

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
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
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }
    }
}
