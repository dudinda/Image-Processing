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
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
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
          ISubscriber<ReplaceImageEventArgs>, ISubscriber<TrackBarEventArgs>,
          ISubscriber<UndoRedoEventArgs>, ISubscriber<FormIsClosedEventArgs>,
          ISubscriber<ShowRotationMenuEventArgs>, ISubscriber<ShowScalingMenuEventArgs>
    {
        private readonly ILoggerService _logger;
        private readonly IScalingProvider _scale;
        private readonly IRotationProvider _rotation;
        private readonly IAwaitablePipeline _pipeline;
        private readonly ICacheService<Bitmap> _cache;
        private readonly IAsyncOperationLocker _operation;
        private readonly INonBlockDialogService _dialog;

        public MainPresenter(
            INonBlockDialogService dialog,
            IAsyncOperationLocker operation,
            ICacheService<Bitmap> cache,
            IAwaitablePipeline pipeline,
            IRotationProvider rotation,
            IScalingProvider scale,
            ILoggerService logger)
        {
            _scale = scale;
            _cache = cache;
            _logger = logger;
            _dialog = dialog;
            _rotation = rotation;
            _pipeline = pipeline;
            _operation = operation;
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
                      await Render(
                          block: new PipelineBlock(result.Image)
                              .Add<Bitmap>(
                                  (bmp) => View.SetPathToFile(result.Path)),
                          ImageContainer.Source
                      ).ConfigureAwait(true);

                    Aggregator.PublishFromAll(publisher,
                       new ContainerUpdatedEventArgs(ImageContainer.Source, result.Image));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                       ImageContainer.Source
                   ).ConfigureAwait(true);

                    Controller.Run<RgbPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                       ImageContainer.Source
                   ).ConfigureAwait(true);

                    Controller.Run<ScalingPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                       ImageContainer.Source
                   ).ConfigureAwait(true);

                    Controller.Run<RotationPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                       ImageContainer.Source
                   ).ConfigureAwait(true);

                    Controller.Run<DistributionPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Controller.Run<ConvolutionPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Controller.Run<TransformationPresenter, BitmapViewModel>(
                        new BitmapViewModel(copy));
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
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    if (e.Block is IPipelineBlock block)
                    {
                        await Render(block).ConfigureAwait(true);

                        Aggregator.PublishFrom(publisher, new RestoreFocusEventArgs());
                    }
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

        /// <inheritdoc cref="ReplaceImageEventArgs"/>
        public async Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {
            try
            {
                var (to, from) = e.Container == ImageContainer.Source   ?
                    (ImageContainer.Destination, ImageContainer.Source) :
                    (ImageContainer.Source, ImageContainer.Destination);

                if (!View.ImageIsDefault(from))
                {
                    var copy = await GetImageCopy(from)
                        .ConfigureAwait(true);

                    await Render(
                        new PipelineBlock(copy), to
                    ).ConfigureAwait(true);
                  
                    Aggregator.PublishFromAll(publisher,
                        new ContainerUpdatedEventArgs(to, copy));
                }
            }
            catch (OperationCanceledException ex)
            {
                OnError(publisher, Errors.CancelOperation);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ReplaceImage);
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

                if (!View.ImageIsDefault(container))
                {
                    var scale = View.GetZoomFactor(container);
                    var rad   = View.GetRotationFactor(container);

                    var copy = await GetImageCopy(container).ConfigureAwait(true);

                    await Paint(
                        new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _scale.Scale(bmp, scale, scale))
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _rotation.Rotate(bmp, rad)),
                        container
                     ).ConfigureAwait(true);
                }
            }
            catch(ArgumentException ex)
            {
                View.SetDefaultImage(container);
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
                var (copy, to) = View.TryUndoRedo(e.Action);

                var action = e.Action == UndoRedoAction.Redo ?
                   UndoRedoAction.Undo : UndoRedoAction.Redo;
                 
                await Render(
                    new PipelineBlock(copy), to, action
                ).ConfigureAwait(true);

                Aggregator.PublishFromAll(publisher,
                    new ContainerUpdatedEventArgs(to, copy));
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

        public async Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            Controller.Dispose();
        }

        private void RenderBlock(Bitmap bmp, ImageContainer to, UndoRedoAction action)
        {
            lock (_cache)
            {
                View.AddToUndoRedo(to, new Bitmap(View.GetImageCopy(to)), action);
                View.SetImageCopy(to, new Bitmap(bmp));
                View.SetImage(to, new Bitmap(bmp));
                View.SetImageCenter(to, bmp.Size);
                View.Refresh(to);
                View.ResetTrackBarValue(to);
            }          
        }

        private void PaintBlock(Bitmap bmp, ImageContainer to)
        {
            lock (_scale)
            {
                var size = bmp.Size;
                View.SetImage(to, bmp);
                View.SetImageCenter(to, size);
                View.Refresh(to);
            }
        }

        private async Task<Bitmap> GetImageCopy(ImageContainer container)
            => await _operation.LockOperationAsync(
                () => new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);

        private async Task Paint(IPipelineBlock block,
            ImageContainer container = ImageContainer.Destination)
        {
            if (
                !_pipeline
                    .Register(block
                        .Add<Bitmap>(
                            (bmp) => PaintBlock(bmp, container)
                         )
                     )
                 )
            {
                throw new InvalidOperationException(Errors.Pipeline);
            }

            await _pipeline.AwaitResult().ConfigureAwait(true);
        }

        private async Task Render(IPipelineBlock block,
            ImageContainer container = ImageContainer.Destination,
            UndoRedoAction action    = UndoRedoAction.Undo)
        {
            View.SetCursor(CursorType.Wait);

            if (
                !_pipeline
                    .Register(block
                        .Add<Bitmap>(
                            (bmp) => RenderBlock(bmp, container, action)
                         )
                     )
                 )
            {
                throw new InvalidOperationException(Errors.Pipeline);
            }

            await _pipeline.AwaitResult().ConfigureAwait(true);

            if (container == ImageContainer.Source)
            {
                _cache.Reset();
            }
      
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
