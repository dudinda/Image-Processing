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
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.App.UILayer")]
namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    internal sealed partial class MainPresenter : BasePresenter<IMainView>,
          ISubscriber<AttachBlockToRendererEventArgs>,
          ISubscriber<ShowConvolutionMenuEventArgs>,
          ISubscriber<ReplaceImageEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowRgbMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        private readonly ICacheService<Bitmap> _cache;
        private readonly INonBlockDialogService _nonBlock;
        private readonly IMainPresenterLockersFacade _locker;
        private readonly IAwaitablePipeline _pipeline;

        public MainPresenter(
            IAppController controller,
            ICacheService<Bitmap> cache,
            INonBlockDialogService nonBlock,
            IAwaitablePipeline pipeline,
            IMainPresenterLockersFacade locker) : base(controller)
        {
            _cache = cache;
            _nonBlock = nonBlock;
            _locker = locker;
            _pipeline = pipeline;
        }

        public async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            try
            {
                var result = await _nonBlock.NonBlockOpen(
                    ConfigurationManager.AppSettings["Filters"]
                ).ConfigureAwait(true);

                if (result.Image != null)
                {
                    View.SetCursor(CursorType.Wait);

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

        public async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    await _nonBlock.NonBlockSaveAs(copy,
                         ConfigurationManager.AppSettings["Filters"]
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
            }
        }

        public async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    await Task.Run(
                        () => copy.SaveByPath(View.PathToFile)
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
            }
        }

        public async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                       ImageContainer.Source
                   ).ConfigureAwait(true);

                    Controller.Run<RgbPresenter, RgbViewModel>(
                        new RgbViewModel(copy)
                    );

                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ApplyRgbFilter);
            }
        }

        public async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Controller.Run<ConvolutionPresenter, ConvolutionFilterViewModel>(
                        new ConvolutionFilterViewModel(copy)
                    );
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.ShowConvolutionMenu);
            }
        }

        public async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var block = e.Block as IPipelineBlock;

                    if (block != null)
                    {
                        View.SetCursor(CursorType.Wait);

                        await Render(
                            block, ImageContainer.Destination
                        ).ConfigureAwait(true);
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

        public async Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {
            try
            {
                var (To, From) = e.Container == ImageContainer.Source ?
                    (ImageContainer.Destination, ImageContainer.Source) :
                    (ImageContainer.Source, ImageContainer.Destination);

                if (!View.ImageIsNull(From))
                {
                    View.SetCursor(CursorType.Wait);

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
    
        public async Task OnEventHandler(object publisher, ZoomEventArgs e)
        {
            try
            {
                var container = e.Container;

                if (!View.ImageIsNull(container))
                {
                    var image = await _locker.LockZoomAsync(() =>
                        View.ZoomImage(container)
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

        private Bitmap DefaultPipelineBlock(Bitmap bmp, ImageContainer to)
        {
            lock (this)
            {
                View.SetImageCopy(to, new Bitmap(bmp));
                View.AddToUndoContainer( (new Bitmap(View.GetImageCopy(to)), to) );
                View.SetImageToZoom(to, new Bitmap(bmp));

                return (Bitmap)View.GetImageCopy(to).Clone();
            }
        }

        private async Task<Bitmap> GetImageCopy(ImageContainer container)
            => await _locker.LockOperationAsync(() =>
                  new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);


        private async Task Render(IPipelineBlock block, ImageContainer container)
        {
            if (
                _pipeline
                    .Register(block
                        .Add<Bitmap, Bitmap>(
                            (bmp) => DefaultPipelineBlock(bmp, container)
                         )
                     )
                 )
            {
                var result = await _pipeline
                .AwaitResult()
                .ConfigureAwait(true);

                if (container == ImageContainer.Source)
                {
                    _cache.Reset();
                }

                View.SetImage(container, (Bitmap)result);
                View.Refresh(container);
                View.ResetTrackBarValue(container);

                if (!_pipeline.Any())
                {
                    View.SetCursor(CursorType.Default);
                }

            }

            throw new InvalidOperationException();
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

        public void CloseForm(CloseFormEventArgs e)
            => Controller.Dispose();

        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);

            return Task.CompletedTask;
        }
    }
}
