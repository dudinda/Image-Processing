using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class ColorMatrixPresenter : BasePresenter<IColorMatrixView, BitmapViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>, ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>
    {
        private readonly IRgbProvider _provider;
        private readonly ILoggerService _logger;
        private readonly IColorMatrixFactory _factory;
        private readonly IAsyncOperationLocker _locker;

        public ColorMatrixPresenter(
            IAsyncOperationLocker locker,
            IColorMatrixFactory factory,
            ILoggerService logger,
            IRgbProvider provider)
        {
            _provider = provider;
            _logger = logger;
            _factory = factory;
            _locker = locker;         
        }

        /// <inheritdoc cref="ApplyColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyColorMatrixEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ClrMatrix.Unknown)
                {
                    var copy = await _locker.LockOperationAsync(
                        () => new Bitmap(ViewModel.Source)
                    ).ConfigureAwait(true);

                    Aggregator.PublishFromAll(publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _provider.Apply(bmp, filter))
                        )
                     );
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyColorMatrix);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ApplyCustomColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyCustomColorMatrixEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var matrix = View.GetGrid();

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, matrix))
                    )
                 );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyCustomColorMatrix);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="CustomColorMatrixEventArgs"/>
        public Task OnEventHandler(object publisher, CustomColorMatrixEventArgs e)
        {
            try
            {
                View.SetEnabledCells(!e.UseCustom);
                View.SetEnabledDropDown(!e.UseCustom);
                View.SetVisibleApply(!e.UseCustom);
                View.SetVisibleApplyCustom(e.UseCustom);
                View.SetGrid(_factory.Get(View.Dropdown).Matrix);
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.CustomColorMatrix);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ChangeColorMatrixEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeColorMatrixEventArgs e)
        {
            try
            {
                View.SetGrid(_factory.Get(View.Dropdown).Matrix);
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdateColorMatrix);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                await _locker.LockOperationAsync(() =>
                {
                    lock (e.Bmp)
                    {
                        ViewModel.Source = new Bitmap(e.Bmp);
                    }
                }).ConfigureAwait(true);
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
            catch(Exception ex)
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
