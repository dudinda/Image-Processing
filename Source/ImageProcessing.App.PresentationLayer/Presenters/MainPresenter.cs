using System;
using System.Configuration;
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
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions.BitmapExt;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class MainPresenter : BasePresenter<IMainView>,
          ISubscriber<AttachBlockToRendererEventArgs>,
          ISubscriber<ShowConvolutionMenuEventArgs>,
          ISubscriber<ShowDistributionMenuEventArgs>,
          ISubscriber<ShowRgbMenuEventArgs>,
          ISubscriber<ShowSettingsMenuEventArgs>,
          ISubscriber<ShowTransformationMenuEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ReplaceImageEventArgs>,
          ISubscriber<TrackBarEventArgs>,
          ISubscriber<UndoRedoEventArgs>,
          ISubscriber<FormIsClosedEventArgs>
    {
        private readonly ICacheService<Bitmap> _cache;
        private readonly INonBlockDialogService _dialog;
        private readonly IAsyncOperationLocker _operation;
        private readonly IScalingProvider _scale;
        private readonly IRotationProvider _rotation;
        private readonly IAwaitablePipeline _pipeline;

        public MainPresenter(
            ICacheService<Bitmap> cache,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IAsyncOperationLocker operation,
            IScalingProvider scale,
            IRotationProvider rotation)
        {
            _cache = cache;
            _dialog = dialog;
            _operation = operation;
            _scale = scale;
            _rotation = rotation;
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
                      await Render(
                          block: new PipelineBlock(result.Image)
                              .Add<Bitmap>(
                                  (bmp) => View.SetPathToFile(result.Path)),
                          ImageContainer.Source
                      ).ConfigureAwait(true);

                    Controller.Aggregator.PublishFromAll(publisher,
                       new ContainerUpdatedEventArgs(
                           ImageContainer.Source, result.Image));
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.OpenFile);
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

                    Controller.Run<RgbPresenter, RgbViewModel>(
                        new RgbViewModel(copy));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowRgbMenu);
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

                    Controller.Run<DistributionPresenter, DistributionViewModel>(
                        new DistributionViewModel(copy));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowDistributionMenu);
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

                    Controller.Run<ConvolutionPresenter, ConvolutionViewModel>(
                        new ConvolutionViewModel(copy));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowConvolutionMenu);
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

                    Controller.Run<TransformationPresenter, TransformationViewModel>(
                        new TransformationViewModel(copy));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowTransformationMenu);
            }
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            try
            {
                Controller.Run<SettingsPresenter>();
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowSettingsMenu);
            }
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

                        Controller.Aggregator.PublishFrom(publisher,
                            new RestoreFocusEventArgs());
                    }
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(publisher, Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Pipeline);
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
                  
                    Controller.Aggregator.PublishFromAll(publisher,
                        new ContainerUpdatedEventArgs(to, copy));
                }
            }
            catch (OperationCanceledException ex)
            {
                OnError(publisher, Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ReplaceImage);
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

                    var copy = await GetImageCopy(container)
                        .ConfigureAwait(true);

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

                Controller.Aggregator.PublishFromAll(publisher,
                        new ContainerUpdatedEventArgs(to, copy));
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Message);
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

            Controller.Aggregator.PublishFrom(publisher,
                new ShowTooltipOnErrorEventArgs(error));
        }
    }
}
