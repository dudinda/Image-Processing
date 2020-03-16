using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.Pipeline.Block.Implementation;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.PresentationLayer.Presenters.Convolution;
using ImageProcessing.PresentationLayer.ViewModel.Convolution;
using ImageProcessing.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.PresentationLayer.Views.Main;
using ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.ServiceLayer.Services.StaTask.Interface;

namespace ImageProcessing.PresentationLayer.Presenters.Main
{
    public sealed partial class MainPresenter : BasePresenter<IMainView>
    {

        private readonly IBitmapLuminanceDistributionServiceProvider _lumaProvider;
        private readonly IRgbFilterServiceProvider _rgbProvider;
        private readonly ISTATaskService _staTaskService;
        private readonly IAsyncZoomLocker _zoomLocker;
        private readonly IAsyncOperationLocker _operationLocker;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             ISTATaskService staTaskService,
                             IEventAggregator eventAggregator,
                             IAwaitablePipeline pipeline,
                             IAsyncZoomLocker zoomLocker,
                             IAsyncOperationLocker operationLocker,
                             IBitmapLuminanceDistributionServiceProvider lumaProvider,
                             IRgbFilterServiceProvider rgbProvider

            ) : base(controller, view, pipeline, eventAggregator)
        {
            _lumaProvider = Requires.IsNotNull(
                lumaProvider, nameof(lumaProvider)
            );
            _rgbProvider = Requires.IsNotNull(
                rgbProvider, nameof(rgbProvider)
            );
            _staTaskService = Requires.IsNotNull(
                staTaskService, nameof(staTaskService)
            );
            _zoomLocker = Requires.IsNotNull(
                zoomLocker, nameof(zoomLocker)
            );
            _operationLocker = Requires.IsNotNull(
                operationLocker, nameof(operationLocker)
            );

            EventAggregator.Subscribe(this);
        }

        private async Task OpenImage()
        {
            try
            {
                var openResult = await _staTaskService.StartSTATask(() =>
                {
                    using (var dialog = new OpenFileDialog())
                    {
                        dialog.InitialDirectory = Environment.GetFolderPath(
                            Environment.SpecialFolder.Personal 
                        );

                        dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            View.PathToFile = dialog.FileName;

                            return Task.Run(() =>
                            {
                                using (var stream = File.OpenRead(dialog.FileName))
                                {
                                    return new Bitmap(
                                        Image.FromStream(stream)
                                    );
                                }
                            });
                        }

                        return Task.FromResult<Bitmap>(null);
                    }
                }).ConfigureAwait(true);

                var result = await openResult.ConfigureAwait(true);

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

        private async Task SaveImageAs()
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var saveAsModalTask = await _staTaskService.StartSTATask(() =>
                    {
                        using (var dialog = new SaveFileDialog())
                        {
                            dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                return _operationLocker.LockAsync(() =>
                                {
                                    new Bitmap(View.SrcImageCopy)
                                        .Save(
                                            dialog.FileName,
                                            Path.GetExtension(
                                                dialog.FileName
                                        ).GetImageFormat()
                                    );
                                });
                            }

                            return Task.FromResult<object>(null);
                        }
                    }).ConfigureAwait(true);

                    await saveAsModalTask.ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.ShowError("Error while saving the file.");
            }
        }

        private async Task SaveImage()
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    await _operationLocker.LockAsync(() =>
                    {
                        new Bitmap(View.SrcImageCopy)
                            .Save(
                                View.PathToFile,
                                Path.GetExtension(
                                    View.PathToFile
                            ).GetImageFormat()
                        );
                    }).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.ShowError("Error while saving the file.");
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
                        .Register(e.Arg
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
                View.ShowError("Error while applying a convolution filter.");
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
                                (bmp) => _rgbProvider.Apply(bmp, e.Arg)
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
                    var result = View.GetSelectedColors(e.Arg);

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

                    Pipeline
                        .Register(new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _lumaProvider.Transform(bmp, e.Arg, e.Parameters)
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

        private async Task Shuffle()
        {
            try
            {
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

        private async Task BuildFunction(RandomVariableEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(e.Arg))
                {
                    Controller.Run<HistogramPresenter, HistogramViewModel>(
                        new HistogramViewModel(
                            new Bitmap(
                                await GetImageCopy(
                                    e.Arg
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
                switch (e.Arg)
                {
                    case ImageContainer.Source:
                        container = (ImageContainer.Destination, ImageContainer.Source);
                        break;
                    case ImageContainer.Destination:
                        container = (ImageContainer.Source, ImageContainer.Destination);
                        break;

                    default: throw new NotImplementedException(nameof(e.Arg));
                }
            };
        }

        private async Task GetRandomVariableInfo(RandomVariableEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                var container = e.Arg;

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

                var container = e.Arg;

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
            View.SetImageCopy(to, new Bitmap(bmp));

            View.AddToUndoContainer(
                (new Bitmap(View.GetImageCopy(to)), to)
            );

            View.SetImageToZoom(to, new Bitmap(bmp));

            return (Bitmap)View.GetImageCopy(to).Clone();
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
        {
            _staTaskService.Dispose();
            Controller.Dispose();
        }
    }
}
