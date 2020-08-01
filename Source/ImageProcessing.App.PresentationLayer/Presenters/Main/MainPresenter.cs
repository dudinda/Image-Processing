using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
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
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.App.UILayer")]
namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    internal sealed partial class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IBitmapLuminanceDistributionServiceProvider _lumaProvider;
        private readonly IRgbFilterServiceProvider _rgbProvider;
        private readonly IAsyncZoomLocker _zoomLocker;
        private readonly IAsyncOperationLocker _operationLocker;
        private readonly ICacheService<Bitmap> _cache;
        private readonly INonBlockDialogService _nonBlock;

        public MainPresenter(IAppController controller,
                             IAsyncZoomLocker zoomLocker,
                             IAsyncOperationLocker operationLocker,
                             IBitmapLuminanceDistributionServiceProvider lumaProvider,
                             IRgbFilterServiceProvider rgbProvider,
                             ICacheService<Bitmap> cache,
                             INonBlockDialogService nonBlock)
            : base(controller)
        {
            _lumaProvider = lumaProvider;
            _rgbProvider = rgbProvider;
            _zoomLocker = zoomLocker;
            _operationLocker = operationLocker;
            _cache = cache;
            _nonBlock = nonBlock;
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

                    if(
                        Pipeline
                            .Register(new PipelineBlock(result.Image)
                                .Add<Bitmap>(
                                    (bmp) => View.SetPathToFile(result.Path)
                                )
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Source)
                                 )
                             )
                        )
                    {
                        await Render(
                            ImageContainer.Source
                        ).ConfigureAwait(true);
                    }
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
                    var copy = await GetImageCopy(ImageContainer.Source)
                        .ConfigureAwait(true);

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

                    await Task.Run(() => copy.Save(
                        View.PathToFile,
                        Path.GetExtension(
                            View.PathToFile
                        ).GetImageFormat()
                     )).ConfigureAwait(true);
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

                        if (
                            Pipeline
                                .Register(block
                                    .Add<Bitmap, Bitmap>(
                                        (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                    )
                                )
                            )
                        {
                            await Render(
                                ImageContainer.Destination
                            ).ConfigureAwait(true);
                        }
                    }
                }
            }
            catch (OperationCanceledException cancelEx)
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

                    if(
                        Pipeline
                            .Register(new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _rgbProvider.Apply(bmp, e.Filter)
                                )
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                )
                            )
                        )
                    {
                        await Render(
                            ImageContainer.Destination
                        ).ConfigureAwait(true);
                    }         
                }
            }
            catch (OperationCanceledException cancelEx)
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

                        if(
                            Pipeline
                                .Register(new PipelineBlock(copy)
                                    .Add<Bitmap, Bitmap>(
                                        (bmp) => _rgbProvider.Apply(bmp, result)
                                    )
                                    .Add<Bitmap, Bitmap>(
                                        (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                    )
                                )
                            )
                        {
                            await Render(
                                ImageContainer.Destination
                            ).ConfigureAwait(true);
                        }                                   
                    }
                    else
                    {
                        View.SetImage(ImageContainer.Destination, View.DstImage);
                    }
                }
            }
            catch (OperationCanceledException cancelEx)
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

                    if(
                        Pipeline
                            .Register(new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _lumaProvider.Transform(bmp, e.Distribution, e.Parameters)
                                )
                                .Add<Bitmap>(
                                    (bmp) => View.AddToQualityMeasureContainer(bmp)
                                )
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                )
                            )
                        )
                    {
                        await Render(
                            ImageContainer.Destination
                        ).ConfigureAwait(true);

                        View.EnableQualityQueue(true);
                    }          
                }
            }
            catch (OperationCanceledException cancelEx)
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

                    if(
                        Pipeline
                            .Register(new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => bmp.Shuffle()
                                )
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                 )
                            )
                        )
                    {
                        await Render(
                            ImageContainer.Destination
                        ).ConfigureAwait(true);
                    }
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
                var (To, From) = e.Container == ImageContainer.Source   ?
                    (ImageContainer.Destination, ImageContainer.Source) :
                    (ImageContainer.Source, ImageContainer.Destination);

                if (!View.ImageIsNull(From))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(From).ConfigureAwait(true);

                    if(
                        Pipeline
                            .Register(new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, To)
                                )
                            )
                        )
                    {
                        await Render(To).ConfigureAwait(true);
                    }               
                }
            }
            catch (OperationCanceledException cancelEx)
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
                        () => _lumaProvider.GetInfo(copy, e.Action)
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
                    var image = await _zoomLocker.LockAsync(() =>
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
            => await _operationLocker.LockAsync(() =>
                  new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);

        private async Task Render(ImageContainer container)
        {
            var result = await Pipeline
                .AwaitResult()
                .ConfigureAwait(true);

            if (container == ImageContainer.Source)
            {
                _cache.Reset();
            }

            View.SetImage(container, (Bitmap)result);
            View.Refresh(container);
            View.ResetTrackBarValue(container);

            if (!Pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
        }

        private void OnError(string error)
        {
            View.ShowError(error);

            if (!Pipeline.Any())
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
