using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Code.Constants;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class MainPresenter : BasePresenter<IMainView>,
        ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<ShowConvolutionMenuEventArgs>,
        ISubscriber<ShowDistributionMenuEventArgs>, ISubscriber<ShowRgbMenuEventArgs>,
        ISubscriber<ShowSettingsMenuEventArgs>, ISubscriber<ShowTransformationMenuEventArgs>,
        ISubscriber<OpenFileDialogEventArgs>, ISubscriber<SaveAsFileDialogEventArgs>,
        ISubscriber<SaveWithoutFileDialogEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<TrackBarEventArgs>, ISubscriber<UndoRedoEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<ShowRotationMenuEventArgs>,
        ISubscriber<ShowScalingMenuEventArgs>, ISubscriber<SetSourceEventArgs>
    {
        private readonly ILoggerService _logger;
        private readonly IScalingProvider _scale;
        private readonly IRotationProvider _rotation;
        private readonly IBitmapCopyService _reference;
        private readonly IAwaitablePipeline _pipeline;
        private readonly INonBlockDialogService _dialog;

        public MainPresenter(
            IBitmapCopyService reference,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IRotationProvider rotation,
            IScalingProvider scale,
            ILoggerService logger)
        {
            _scale = scale;
            _logger = logger;
            _dialog = dialog;
            _rotation = rotation;
            _reference = reference;
            _pipeline = pipeline;
        }

        /// <inheritdoc cref="OpenFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            try
            {
                  var result = await _dialog.NonBlockOpen(
                      ConfigurationManager.AppSettings[AppSettingsKeys.Filters]
                  ).ConfigureAwait(true);

                if (result.Image != null)
                {
                    View.LoadedImage = result.Image;

                    await Render(publisher,
                        block: new PipelineBlock(result.Image)
                            .Add<Bitmap>(
                                (bmp) => View.SetPathToFile(result.Path))
                    ).ConfigureAwait(true);

                    View.SetMenuState(MenuBtnState.ImageLoaded);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.OpenFile);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="SaveAsFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    await _dialog.NonBlockSaveAs(copy,
                         ConfigurationManager.AppSettings[AppSettingsKeys.Filters]
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="SaveWithoutFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    await Task.Run(
                        () => copy.SaveByPath(View.GetPathToFile())
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<RgbPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowRgbMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<ScalingPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowRgbMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<RotationPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowRgbMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<DistributionPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowDistributionMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<ConvolutionPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowConvolutionMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<TransformationPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowTransformationMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            try
            {
                Controller.Run<SettingsPresenter>();
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowSettingsMenu);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="AttachBlockToRendererEventArgs"/>
        public async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault && e.Block is IPipelineBlock block)
                {
                    await Render(publisher, block).ConfigureAwait(true);

                    Aggregator.PublishFrom(publisher, new RestoreFocusEventArgs());
                }
            }
            catch (OperationCanceledException ex)
            {
                OnError(publisher, Errors.CancelOperation);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Pipeline);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="TrackBarEventArgs"/>
        public async Task OnEventHandler(object publisher, TrackBarEventArgs e)
        {
            var container = ImageContainer.Unknown;

            try
            {
                container = e.Container;

                if (!View.ImageIsDefault)
                {
                    var scale = View.GetZoomFactor();
                    var rad   = View.GetRotationFactor();

                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    await Paint(
                        new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _scale.Scale(bmp, scale, scale))
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _rotation.Rotate(bmp, rad))
                     ).ConfigureAwait(true);
                }
            }
            catch(ArgumentException ex)
            {
                View.SetDefaultImage();
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.Zoom);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="UndoRedoEventArgs"/>
        public async Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            try
            {
                var copy = View.TryUndoRedo(e.Action);
                var action = e.Action == UndoRedoAction.Redo ?
                   UndoRedoAction.Undo : UndoRedoAction.Redo;

                Enum.TryParse<MenuBtnState>(copy.Tag?.ToString(), out var state);

                await Render(publisher, new PipelineBlock(copy), action).ConfigureAwait(true);

                if(state != MenuBtnState.ImageEmpty)
                {
                    state = MenuBtnState.ImageLoaded;
                }

                View.SetMenuState(state);
                Aggregator.PublishFromAll(publisher, new ContainerUpdatedEventArgs(copy));
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
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
            catch(Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            
            return Task.CompletedTask;
        }

        public async Task OnEventHandler(object publisher, SetSourceEventArgs e)
        {
            try
            {
                await Render(publisher,
                        block: new PipelineBlock(new Bitmap(View.LoadedImage))
                ).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                Controller.Dispose();
            }
            catch(Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        private void RenderBlock(object publisher, Bitmap bmp, UndoRedoAction action)
        {
            lock (_dialog)
            {
                View.AddToUndoRedo((Bitmap)View.GetImageCopy(), action);
                View.SetImageCopy(bmp);
                View.SetImage(bmp);
                View.SetImageCenter(bmp.Size);
                View.Refresh();
                View.ResetTrackBarValue();

                if(Enum.TryParse<MenuBtnState>(bmp.Tag?.ToString(), out var tag))
                {
                    View.GetImageCopy().Tag = tag;
                }
                _reference.SetCopy(new Bitmap(bmp)).Wait();
                Aggregator.PublishFromAll(publisher, new EnableControlEventArgs(tag));
                Aggregator.PublishFromAll(publisher, new ContainerUpdatedEventArgs(bmp));
            }
        }

        private void PaintBlock(Bitmap bmp)
        {
            lock (_scale)
            {
                var size = bmp.Size;
                View.SetImage(bmp);
                View.SetImageCenter(size);
                View.Refresh();
            }
        }

        private async Task Paint(IPipelineBlock block)
        {
            if (
                !_pipeline
                    .Register(block
                        .Add<Bitmap>(
                            (bmp) => PaintBlock(bmp)
                         )
                     )
                 )
            {
                throw new InvalidOperationException(Errors.Pipeline);
            }

            await _pipeline.AwaitResult().ConfigureAwait(true);
        }

        private async Task Render(object publisher, IPipelineBlock block,
            UndoRedoAction action    = UndoRedoAction.Undo)
        {
            View.SetCursor(CursorType.Wait);

            if (
                !_pipeline
                    .Register(block
                        .Add<Bitmap>(
                            (bmp) => RenderBlock(publisher, bmp, action)
                         )
                     )
                 )
            {
                throw new InvalidOperationException(Errors.Pipeline);
            }

            await _pipeline.AwaitResult().ConfigureAwait(true);

            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
        }

        private void OnError(object publisher, string error)
        {
            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
            else
            {
                View.SetCursor(CursorType.Wait);
            }

            Aggregator.PublishFrom(publisher,
                new ShowTooltipOnErrorEventArgs(error));
        }
    }
}
