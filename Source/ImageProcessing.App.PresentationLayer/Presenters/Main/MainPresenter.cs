using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterProviders.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.App.UILayer")]
namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    internal sealed partial class MainPresenter : BasePresenter<IMainView>
    {
        private readonly ICacheService<Bitmap> _cache;
        private readonly INonBlockDialogService _nonBlock;
        private readonly IMainPresenterLockersFacade _locker;
        private readonly IMainPresenterProvidersFacade _providers;
        private readonly IAwaitablePipeline _pipeline;

        public MainPresenter(
            IAppController controller,
            ICacheService<Bitmap> cache,
            INonBlockDialogService nonBlock,
            IAwaitablePipeline pipeline,
            IMainPresenterLockersFacade locker,
            IMainPresenterProvidersFacade providers) : base(controller)
        {
            _cache = cache;
            _nonBlock = nonBlock;
            _locker = locker;
            _providers = providers;
            _pipeline = pipeline;
        }

        private async Task OpenImage(OpenFileDialogEventArgs e)
        {
            try
            {
                var result = await _nonBlock.NonBlockOpen(
                    ConfigurationManager.AppSettings["Filters"]
                ).ConfigureAwait(true);

                if (result.Image != null)
                {
                    View.SetCursor(CursorType.Wait);

                    var block = new PipelineBlock(result.Image)
                        .Add<Bitmap>((bmp) => View.SetPathToFile(result.Path));

                    await TryRender(
                        block, ImageContainer.Source
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(Errors.OpenFile);
            }
        }

        private async Task SaveImageAs(SaveAsFileDialogEventArgs e)
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
                OnError(Errors.SaveFile);
            }
        }

        private async Task SaveImage(SaveWithoutFileDialogEventArgs e)
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
                OnError(Errors.SaveFile);
            }
        }

        private async Task ShowQualityMeasureForm(ShowQualityMeasureEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    Controller.Run<QualityMeasurePresenter, QualityMeasureViewModel>(
                        new QualityMeasureViewModel(View.GetQualityQueue())
                    );

                    View.EnableQualityQueue(false);
                }
            }
            catch (Exception ex)
            {
                OnError(Errors.QualityHistogram);
            }
        }

        private async Task ShowConvolutionFiltersMenu(ShowConvolutionFilterPresenterEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Controller.Run<ConvolutionFilterPresenter, ConvolutionFilterViewModel>(
                        new ConvolutionFilterViewModel(copy)
                    );
                }
            }
            catch (Exception ex)
            {
                OnError(Errors.ShowConvolutionMenu);
            }
        }

        private async Task ApplyConvolutionFilter(ApplyConvolutionFilterEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var block = e.Block as IPipelineBlock;

                    if (block != null)
                    {
                        View.SetCursor(CursorType.Wait);

                        await TryRender(
                            block, ImageContainer.Destination
                        ).ConfigureAwait(true);
                    }
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(Errors.ApplyConvolutionFilter);
            }
        }

        private async Task ApplyRgbFilter(RgbFilterEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    var block = new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _providers.Apply(bmp, e.Filter)
                                );

                    await TryRender(
                        block, ImageContainer.Destination
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(Errors.ApplyRgbFilter);
            }
        }

        private async Task ApplyColorFilter(RgbColorFilterEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var result = View.GetSelectedColors(e.Color);

                    if (result != RgbColors.Unknown)
                    {
                        View.SetCursor(CursorType.Wait);

                        var copy = await GetImageCopy(
                            ImageContainer.Source
                        ).ConfigureAwait(true);

                        var block = new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>((bmp) => _providers.Apply(bmp, result));

                        await TryRender(
                            block, ImageContainer.Destination
                        ).ConfigureAwait(true);

                    }
                    else
                    {
                        View.SetImage(ImageContainer.Destination, View.DstImage);
                    }
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(Errors.ApplyColorFilter);
            }
        }

        private async Task ApplyHistogramTransformation(DistributionEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    copy.Tag = e.Distribution.ToString();

                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>(
                            (bmp) => _providers.Transform(bmp, e.Distribution, e.Parameters)
                         )
                        .Add<Bitmap>(
                            (bmp) => View.AddToQualityMeasureContainer(bmp)
                         );

                    await TryRender(
                        block, ImageContainer.Destination
                    ).ConfigureAwait(true);

                    View.EnableQualityQueue(true);
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(Errors.TransformHistogram);
            }      
        }

        private async Task Shuffle(ShuffleEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>((bmp) => bmp.Shuffle());

                    await TryRender(
                        block, ImageContainer.Destination
                    ).ConfigureAwait(true);
                }
            }
            catch
            {
                OnError(Errors.Shuffle);
            }
        }

        private async Task BuildFunction(RandomVariableFunctionEventArgs e)
        {
            try
            {
                if (!View.ImageIsNull(e.Container))
                {
                    var copy = await GetImageCopy(
                        e.Container
                    ).ConfigureAwait(true);

                    Controller.Run<HistogramPresenter, HistogramViewModel>(
                        new HistogramViewModel(copy, e.Action)
                    );
                }
            }
            catch (Exception ex)
            {
                OnError(Errors.BuildFunction);
            }
        }

        private async Task Replace(ImageContainerEventArgs e)
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

                    await TryRender(
                        new PipelineBlock(copy), To
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancel)
            {
                OnError(Errors.CancelOperation);
            }
            catch (Exception ex)
            {
                OnError(Errors.ReplaceImage);
            }        
        }

        private async Task GetRandomVariableInfo(RandomVariableInfoEventArgs e)
        {
            try
            {
                var container = e.Container;

                if (!View.ImageIsNull(container))
                {
                    var copy = await GetImageCopy(
                        container
                    ).ConfigureAwait(true);

                    var result = await Task.Run(
                        () => _providers.GetInfo(copy, e.Action)
                    ).ConfigureAwait(true);

                    View.ShowInfo(
                        result.ToString(CultureInfo.InvariantCulture)
                    );
                }
            }
            catch (Exception ex)
            {
               OnError(Errors.RandomVariableInfo);
            }
        }

        private async Task Zoom(ZoomEventArgs e)
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
                OnError(Errors.Zoom);
            }
        }

        private Bitmap DefaultPipelineBlock(Bitmap bmp, ImageContainer to)
        {
            lock (this)
            {
                View.SetImageCopy(to, new Bitmap(bmp));
     
                View.AddToUndoContainer(
                    (new Bitmap(View.GetImageCopy(to)), to)
                );

                View.SetImageToZoom(to, new Bitmap(bmp));

                return (Bitmap)View.GetImageCopy(to).Clone();
            }
        }

        private async Task<Bitmap> GetImageCopy(ImageContainer container)
            => await _locker.LockOperationAsync(() =>
                  new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);


        private async Task TryRender(IPipelineBlock block, ImageContainer container)
        {
            var isRendered = await Render(
                block, container
            ).ConfigureAwait(true);

            if (!isRendered)
            {
                throw new InvalidOperationException(nameof(isRendered));
            } 
        }

        private async Task<bool> Render(IPipelineBlock block, ImageContainer container)
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

                return true;
            }

            return false;
        }

        private void OnError(string error)
        {
            View.ShowError(error);

            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
            else
            {
                View.SetCursor(CursorType.Wait);
            }
        }
           
        private void CloseForm(CloseFormEventArgs e)
            => Controller.Dispose();
    }
}
