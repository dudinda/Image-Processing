using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class DistributionPresenter : BasePresenter<IDistributionView, DistributionViewModel>,
        ISubscriber<TransformHistogramEventArgs>,
        ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>,
        ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>
    {
        private readonly IBitmapService _service;
        private readonly ILoggerService _logger;
        private readonly IAsyncOperationLocker _locker;
        private readonly IBitmapLuminanceProvider _provider;
        
        public DistributionPresenter(
            IBitmapLuminanceProvider provider,
            IAsyncOperationLocker locker,
            IBitmapService service,
            ILoggerService logger)
        {
            _locker = locker;
            _logger = logger;
            _service = service;
            _provider = provider;
        }

        /// <inheritdoc cref="TransformHistogramEventArgs"/>
        public async Task OnEventHandler(object publisher, TransformHistogramEventArgs e)
        {
            try
            {
                var distribution = View.Dropdown;

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                copy.Tag = distribution.ToString();

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                       block: new PipelineBlock(copy)
                           .Add<Bitmap, Bitmap>(
                               (bmp) => _provider.Transform(bmp, distribution, e.Parameters))
                           .Add<Bitmap>(
                               (bmp) => View.AddToQualityMeasureContainer(bmp))
                           .Add<Bitmap>(
                               (bmp) => View.EnableQualityQueue(true))
                    )
                );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.TransformHistogram);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShuffleEventArgs"/>
        public async Task OnEventHandler(object publisher, ShuffleEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _service.Shuffle(bmp))
                    )
                 );                     
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.Shuffle);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="BuildRandomVariableFunctionEventArgs"/>
        public async Task OnEventHandler(object publisher, BuildRandomVariableFunctionEventArgs e)
        {
            try
            {
                var copy = await _locker .LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Run<HistogramPresenter, HistogramViewModel>(
                    new HistogramViewModel(copy, e.Action));
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.BuildFunction);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowQualityMeasureMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowQualityMeasureMenuEventArgs e)
        {
            try
            {
                Controller.Run<QualityMeasurePresenter, QualityMeasureViewModel>(
                    new QualityMeasureViewModel(View.GetQualityQueue()));

                View.EnableQualityQueue(false);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.QualityHistogram);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="GetRandomVariableInfoEventArgs"/>
        public async Task OnEventHandler(object publisher, GetRandomVariableInfoEventArgs e)
        {
            try
            {
                var container = e.Container;

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var result = await Task.Run(
                    () => _provider.GetInfo(copy, e.Action)
                ).ConfigureAwait(true);

                 View.Tooltip(result.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.RandomVariableInfo);
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
            catch (Exception ex)
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
