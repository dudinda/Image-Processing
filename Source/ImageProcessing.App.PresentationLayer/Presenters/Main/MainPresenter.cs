using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.BitmapExtensions;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
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

namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    public sealed partial class MainPresenter : BasePresenter<IMainView>
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
            _lumaProvider = Requires.IsNotNull(
                lumaProvider, nameof(lumaProvider));
            _rgbProvider = Requires.IsNotNull(
                rgbProvider, nameof(rgbProvider));
            _zoomLocker = Requires.IsNotNull(
                zoomLocker, nameof(zoomLocker));
            _operationLocker = Requires.IsNotNull(
                operationLocker, nameof(operationLocker));
            _cache = Requires.IsNotNull(
                cache, nameof(cache));
            _nonBlock = Requires.IsNotNull(
                nonBlock, nameof(nonBlock));

            Controller
                .Aggregator
                .Subscribe(this);
        }

        private async Task OpenImage(OpenFileDialogEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                var result = await _nonBlock.NonBlockOpen(
                    ConfigurationManager.AppSettings["Filters"]
                ).ConfigureAwait(true);

                if (result != null)
                {
                    View.SetCursor(CursorType.Wait);

                    Pipeline
                        .Register(new PipelineBlock(result)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Source)
                             )
                         );

                    await Render(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                }
            }
            catch(Exception ex)
            {
                View.ShowError("Error while opening the file.");
            }
        }

        private async Task SaveImageAs(SaveAsFileDialogEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

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
                View.ShowError("Error while saving the file.");
            }
        }

        private async Task SaveImage(SaveWithoutFileDialogEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var copy = await GetImageCopy(ImageContainer.Source)
                        .ConfigureAwait(true);

                    await Task.Run(
                        () => copy.Save(View.PathToFile,
                                        Path.GetExtension(View.PathToFile)
                                            .GetImageFormat())
                        ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.ShowError("Error while saving the file.");
            }
        }

        private async Task ShowQualityMeasureForm(ShowQualityMeasureEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                await Task.Yield();

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    Controller.Run<QualityMeasurePresenter, QualityMeasureViewModel>(
                        new QualityMeasureViewModel(View.GetQualityQueue())
                    );

                    View.ClearQueue();
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Error while building quality measure histogram.");
            }
        }

        private async Task ShowConvolutionFiltersMenu(ShowConvolutionFilterPresenterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    Controller.Run<ConvolutionFilterPresenter, ConvolutionFilterViewModel>(
                        new ConvolutionFilterViewModel(
                            new Bitmap(
                                await GetImageCopy(
                                    ImageContainer.Source
                                ).ConfigureAwait(true)
                            )
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Error while opening a convolution filters menu.");
            }
        }

        private async Task ApplyConvolutionFilter(ApplyConvolutionFilterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    Pipeline
                        .Register((e.Block as IPipelineBlock)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                            )
                        );

                    await Render(
                        ImageContainer.Destination
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancelEx)
            {
                Controller.Aggregator.Publish(
                    new ShowTooltipOnErrorEventArgs(
                        "The operation has been canceled."
                    )
                );
            }
            catch (Exception ex)
            {
                Controller.Aggregator.Publish(
                    new ShowTooltipOnErrorEventArgs(
                        "Error while applying a convolution filter."
                    )
                );
            }
        }

        private async Task ApplyRgbFilter(RgbFilterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Pipeline
                        .Register(new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _rgbProvider.Apply(bmp, e.Filter)
                            )
                            .Add<Bitmap, Bitmap>(
                                (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                            )
                        );

                    await Render(
                        ImageContainer.Destination
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancelEx)
            {
                View.ShowError("The operation has been canceled.");
            }
            catch (Exception ex)
            {
                View.ShowError("Error while applying an RGB filter.");
            }
        }

        private async Task ApplyColorFilter(RgbColorFilterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var result = View.GetSelectedColors(e.Color);

                    if (!IsDefault(result))
                    {
                        View.SetCursor(CursorType.Wait);

                        var copy = await GetImageCopy(
                            ImageContainer.Source
                        ).ConfigureAwait(true);

                        Pipeline
                            .Register(new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _rgbProvider.Apply(bmp, result)
                                )
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                                )
                            );

                        await Render(
                            ImageContainer.Destination
                        ).ConfigureAwait(true);
                    }
                }
            }
            catch (OperationCanceledException cancelEx)
            {
                View.ShowError("The operation has been canceled.");
            }
            catch (Exception ex)
            {
                View.ShowError($"Error while applying a filter by the color channel.");
            }

            bool IsDefault(RgbColors color)
            {
                if(color is default(RgbColors))
                {
                    View.DstImage = View.SrcImage;

                    return true;
                }

                return false;
            };
        }

        private async Task ApplyHistogramTransformation(DistributionEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    copy.Tag = e.Distribution.ToString();

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
                        );

                    await Render(
                        ImageContainer.Destination
                    ).ConfigureAwait(true);
                }

            }
            catch (OperationCanceledException cancelEx)
            {
                View.ShowError("The operation has been canceled.");
            }
            catch (Exception ex)
            {
                View.ShowError("Error while applying a histogram transformation.");
            }      
        }

        private async Task Shuffle(ShuffleEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        ImageContainer.Source
                    ).ConfigureAwait(true);

                    Pipeline
                        .Register(new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => bmp.Shuffle()
                            )
                            .Add<Bitmap, Bitmap>(
                                (bmp) => DefaultPipelineBlock(bmp, ImageContainer.Destination)
                            )
                        );

                    await Render(
                        ImageContainer.Destination
                    ).ConfigureAwait(true);
                }
            }
            catch
            {
                View.ShowError("Error while shuffling the image.");
            }
        }

        private async Task BuildFunction(RandomVariableFunctionEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(e.Container))
                {
                    Controller.Run<HistogramPresenter, HistogramViewModel>(
                        new HistogramViewModel(
                            new Bitmap(
                                await GetImageCopy(
                                    e.Container
                                ).ConfigureAwait(true)
                            ),
                        e.Action)
                    );
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Error while buiding the plot.");
            }
        }

        private async Task Replace(ImageContainerEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                GetDestination(out var container);

                if (!View.ImageIsNull(container.From))
                {
                    View.SetCursor(CursorType.Wait);

                    var copy = await GetImageCopy(
                        container.From
                    ).ConfigureAwait(true);

                    Pipeline
                        .Register(new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => DefaultPipelineBlock(bmp, container.To)
                            )
                        );

                    await Render(
                        container.To
                    ).ConfigureAwait(true);
                }
            }
            catch (OperationCanceledException cancelEx)
            {
                View.ShowError("The operation has been canceled.");
            }
            catch (Exception ex)
            {
                View.ShowError("Error while replacing the image.");
            }

            void GetDestination(out (ImageContainer To, ImageContainer From) container)
            {
                switch (e.Container)
                {
                    case ImageContainer.Source:
                        container = (ImageContainer.Destination, ImageContainer.Source);
                        break;
                    case ImageContainer.Destination:
                        container = (ImageContainer.Source, ImageContainer.Destination);
                        break;

                    default: throw new NotImplementedException(nameof(e.Container));
                }
            };
        }

        private async Task GetRandomVariableInfo(RandomVariableInfoEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

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
                View.ShowError($"Error while getting the information about {e.Action.ToString().ToLower()}.");
            }
        }

        private async Task Zoom(ZoomEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

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
            catch
            {
                View.ShowError("Error while zooming the image.");
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
        {
            return await _operationLocker.LockAsync(() =>
                  new Bitmap(
                      View.GetImageCopy(container)
                  )
            ).ConfigureAwait(true);
        }

        private async Task Render(ImageContainer container)
        {
            try
            {
                var result = await Pipeline
                    .AwaitResult()
                    .ConfigureAwait(true);

                if(container is ImageContainer.Source)
                {
                    _cache.Reset();
                }

                View.SetImage(container, (Bitmap)result);
                View.Refresh(container);
                View.ResetTrackBarValue(container);
            }
            catch (Exception ex)
            {
                View.SetCursor(CursorType.Default);
                throw;
            }
            finally
            {
                if (!Pipeline.Any())
                {
                    View.SetCursor(CursorType.Default);
                }
            }
        }

        private void CloseForm()
            => Controller.Dispose();
    }
}
