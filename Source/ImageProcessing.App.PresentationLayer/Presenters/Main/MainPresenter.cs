using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.ImageContainer;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Presenters.Distribution;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.App.PresentationLayer.ViewModel.Distribution;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.App.UILayer")]
namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    internal class MainPresenter : BasePresenter<IMainView>,
          ISubscriber<AttachBlockToRendererEventArgs>,
          ISubscriber<ShowConvolutionMenuEventArgs>,
          ISubscriber<ShowDistributionMenuEventArgs>,
          ISubscriber<ShowRgbMenuEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ReplaceImageEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<UndoRedoEventArgs>
    {
        protected readonly ICacheService<Bitmap> _cache;
        protected readonly INonBlockDialogService _dialog;
        protected readonly IAsyncOperationLocker _operation;
        protected readonly IAsyncZoomLocker _zoom;
        protected readonly IAwaitablePipeline _pipeline;

        public MainPresenter(
            IAppController controller,
            ICacheService<Bitmap> cache,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IAsyncOperationLocker operation,
            IAsyncZoomLocker zoom) : base(controller)
        {
            _cache = cache;
            _dialog = dialog;
            _operation = operation;
            _zoom = zoom;
            _pipeline = pipeline;
        }

        public virtual async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            try
            {
                  var result = await _dialog.NonBlockOpen(
                      ConfigurationManager.AppSettings["Filters"]
                  ).ConfigureAwait(true);

                  if (result.Image != null)
                  {
                      await Render(
                          block: new PipelineBlock(result.Image)
                              .Add<Bitmap>(
                                  (bmp) => View.SetPathToFile(result.Path)),
                          ImageContainer.Source
                      ).ConfigureAwait(true);
                  }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.OpenFile);
            }
        }

        public virtual async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    await _dialog.NonBlockSaveAs(copy,
                         ConfigurationManager.AppSettings["Filters"]
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
            }
        }

        public virtual async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
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

        public virtual async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
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

        public virtual async Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
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

        public virtual async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Controller.Run<ConvolutionPresenter, ConvolutionFilterViewModel>(
                        new ConvolutionFilterViewModel(copy));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowConvolutionMenu);
            }
        }

        public virtual async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault(ImageContainer.Source))
                {
                    var block = e.Block as IPipelineBlock;

                    if (block != null)
                    {
                        await Render(block).ConfigureAwait(true);
                    }
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(publisher, Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ApplyConvolutionFilter);
            }
        }

        public virtual async Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {
            try
            {
                var (To, From) = e.Container == ImageContainer.Source   ?
                    (ImageContainer.Destination, ImageContainer.Source) :
                    (ImageContainer.Source, ImageContainer.Destination);

                if (!View.ImageIsDefault(From))
                {
                    var copy = await GetImageCopy(From)
                        .ConfigureAwait(true);

                    await Render(
                        new PipelineBlock(copy), To
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(publisher, Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ReplaceImage);
            }        
        }
    
        public virtual async Task OnEventHandler(object publisher, ZoomEventArgs e)
        {
            try
            {
                var container = e.Container;

                if (!View.ImageIsDefault(container))
                {
                    var image = await _zoom.LockZoomAsync(
                        () => View.ZoomImage(container)
                    ).ConfigureAwait(true);

                    View.SetImage(container, image);
                    View.Refresh(container);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.Zoom);
            }
        }

        public virtual async Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            try
            {
                var (copy, to) = View.TryUndoRedo(e.Action);

                var action = e.Action == UndoRedoAction.Redo ?
                   UndoRedoAction.Undo : UndoRedoAction.Redo;
                 
                await Render(
                    new PipelineBlock(copy), to, action
                ).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
            }
        }

        public virtual async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);
        }

        private void DefaultRenderBlock(Bitmap bmp, ImageContainer to, UndoRedoAction action)
        {
            lock (this)
            {
                var toUndoRedo = new Bitmap(View.GetImageCopy(to));

                if(View.ImageIsDefault(to))
                {
                    toUndoRedo.Tag = nameof(View.ImageIsDefault);
                }

                View.AddToUndoRedo(to, toUndoRedo, action);
                View.SetImageCopy(to, new Bitmap(bmp));
                View.SetImageToZoom(to, new Bitmap(bmp));
                View.SetImage(to, bmp);
                View.Refresh(to);
                View.ResetTrackBarValue(to);
            }
        }

        private async Task<Bitmap> GetImageCopy(ImageContainer container)
            => await _operation.LockOperationAsync(
                () => new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);

        private async Task Render(IPipelineBlock block,
            ImageContainer container = ImageContainer.Destination,
            UndoRedoAction action    = UndoRedoAction.Undo)
        {
            View.SetCursor(CursorType.Wait);

            if (
                !_pipeline
                    .Register(block
                        .Add<Bitmap>(
                            (bmp) => DefaultRenderBlock(bmp, container, action)
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
