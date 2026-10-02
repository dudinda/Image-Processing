using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.Domain.Providers.Rgb;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Domain.Win.Services.Logger;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class ColorMatrixPresenter : BasePresenter<IColorMatrixView, BitmapViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>, ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly IRgbProvider _provider;
        private readonly ILoggerService _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IColorMatrixFactory _factory;

        public ColorMatrixPresenter(
            IBitmapCopyService reference,
            IColorMatrixFactory factory,
            ILoggerService logger,
            IRgbProvider provider)
        {
            _provider = provider;
            _reference = reference;
            _logger = logger;
            _factory = factory;
        }

        /// <inheritdoc cref="ApplyColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyColorMatrixEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ClrMatrix.Unknown)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

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
                var copy = await _reference.GetCopy().ConfigureAwait(true);

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
        public Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                ViewModel.SelectedArea = e.Area;
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            try
            {
                View.EnableControls(e.State != MenuBtnState.ImageEmpty);
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
