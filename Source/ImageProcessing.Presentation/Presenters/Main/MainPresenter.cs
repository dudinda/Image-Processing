using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.ConvolutionFilters.GaussianBlur;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.Pipeline.Block.Implementation;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Core.Service.STATask;
using ImageProcessing.DomainModel.EventArgs;
using ImageProcessing.DomainModel.EventArgs.Convolution;
using ImageProcessing.Presentation.Presenters.Convolution;
using ImageProcessing.Presentation.ViewModel.Convolution;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Services.ConvolutionFilterServices.Implementation;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.RGBFilterService.Interface;

using LightInject;

namespace ImageProcessing.Presentation.Presenters.Main
{
    public partial class MainPresenter : BasePresenter<IMainView>
    {

        private readonly IBitmapLuminanceDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;
        private readonly ISTATaskService _staTaskService;

        private readonly IDistributionFactory _distributionFactory;
        private readonly IRGBFiltersFactory _rgbFiltersFactory;

        private readonly IEventAggregator _eventAggregator;
        private readonly IAwaitablePipeline<Bitmap> _pipeline;

        private readonly IAsyncLocker _zoomLocker;
        private readonly IAsyncLocker _operationLocker;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IBaseFactory baseFactory,
                             IBitmapLuminanceDistributionService distributionService,
                             ISTATaskService staTaskService,
                             IRGBFilterService rgbFilterService,
                             IEventAggregator eventAggregator,
                             IAwaitablePipeline<Bitmap> pipeline,

                             [Inject("ZoomLocker")]
                             IAsyncLocker zoomLocker,

                             [Inject("OperationLocker")]
                             IAsyncLocker operationLocker) : base(controller, view)
        {
            Requires.IsNotNull(baseFactory, nameof(baseFactory));

            _distributionFactory = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory = baseFactory.GetRGBFilterFactory();

            _staTaskService = Requires.IsNotNull(staTaskService, nameof(staTaskService));
            _rgbFilterService = Requires.IsNotNull(rgbFilterService, nameof(rgbFilterService));
            _distributionService = Requires.IsNotNull(distributionService, nameof(distributionService));
            ;

            _eventAggregator = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));
            _pipeline = Requires.IsNotNull(pipeline, nameof(pipeline));

            _zoomLocker = Requires.IsNotNull(zoomLocker, nameof(zoomLocker));
            _operationLocker = Requires.IsNotNull(operationLocker, nameof(operationLocker));

            _eventAggregator.Subscribe(this);
        }

        private async Task OpenImage()
        {
            try
            {
                var openResult = await _staTaskService.StartSTATask<Task<Bitmap>>(() =>
                {
                    using (var dialog = new OpenFileDialog())
                    {
                        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            View.PathToFile = dialog.FileName;

                            return Task.Run(() =>
                            {
                                using (var stream = File.OpenRead(dialog.FileName))
                                {
                                    return new Bitmap(Image.FromStream(stream));
                                }
                            });
                        }

                        return Task.FromResult<Bitmap>(null);
                    }
                }).ConfigureAwait(true);

                var result = await openResult.ConfigureAwait(true);

                if (result != null)
                {
                    View.SetCursor(CursorType.WaitCursor);

                    var block = new PipelineBlock<Bitmap>(result);

                    block.Add<Bitmap, Bitmap>((bmp) =>
                    {
                        View.SrcImageCopy = new Bitmap(bmp);
                        View.SetImageToZoom(ImageContainer.Source, new Bitmap(bmp));
                        View.AddToUndoContainer((new Bitmap(bmp), ImageContainer.Source));
                        return (Bitmap)View.GetImageCopy(ImageContainer.Source).Clone();
                    });

                    _pipeline.Register(block);

                    await UpdateContainer(ImageContainer.Source).ConfigureAwait(true);

                }
            }
            catch
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
                    var saveAsModalTask = await _staTaskService.StartSTATask<Task>(() =>
                    {
                        using (var dialog = new SaveFileDialog())
                        {
                            dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                return _operationLocker.LockAsync(() =>
                                {
                                    var extension = Path.GetExtension(dialog.FileName);

                                    new Bitmap(View.SrcImageCopy).Save(dialog.FileName, extension.GetImageFormat());
                                });
                            }

                            return Task.FromResult<object>(null);
                        }
                    }).ConfigureAwait(false);

                    await saveAsModalTask.ConfigureAwait(true);
                }
            }
            catch
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
                        var extension = Path.GetExtension(View.PathToFile);

                        new Bitmap(View.SrcImageCopy)
                        .Save(View.PathToFile, extension.GetImageFormat());
                    }).ConfigureAwait(true);
                }
            }
            catch
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
                        new ConvolutionFilterViewModel(new Bitmap(await GetImageCopy(ImageContainer.Source).ConfigureAwait(true)))
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
                    View.SetCursor(CursorType.WaitCursor);

                    e.Arg.Add<Bitmap, Bitmap>((image) =>
                    {
                        View.SetImageCopy(ImageContainer.Destination, new Bitmap(image));
                        View.AddToUndoContainer((new Bitmap(image), ImageContainer.Source));
                        View.SetImageToZoom(ImageContainer.Destination, new Bitmap(image));

                        return (Bitmap)View.GetImageCopy(ImageContainer.Destination).Clone();
                    });

                    _pipeline.Register(e.Arg);

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
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

        private async Task ApplyRGBFilter(RGBFilterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    var block = new PipelineBlock<Bitmap>(copy);

                    var operation = _rgbFiltersFactory.GetFilter(e.Arg);

                    block.Add<Bitmap, Bitmap>((bmp) => _rgbFilterService.Filter(bmp, operation));

                    block.Add<Bitmap, Bitmap>((bmp) =>
                    {
                        View.DstImageCopy = new Bitmap(bmp);
                        View.SetImageToZoom(ImageContainer.Destination, new Bitmap(bmp));
                        View.AddToUndoContainer((new Bitmap(bmp), ImageContainer.Source));
                        return (Bitmap)View.GetImageCopy(ImageContainer.Destination).Clone();
                    });

                    _pipeline.Register(block);


                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
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

        private async Task ApplyColorFilter(RGBColorFilterEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (View.ImageIsNull(ImageContainer.Source))
                { return; }

                var result = View.GetSelectedColors(e.Arg);

                if (result is default(RGBColors))
                {
                    View.DstImage = View.SrcImage;
                    return;
                }

                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                var block = new PipelineBlock<Bitmap>(copy);

                var operation = _rgbFiltersFactory.GetColorFilter(result);

                block.Add<Bitmap, Bitmap>((bmp) => operation.Filter(bmp));

                block.Add<Bitmap, Bitmap>((image) =>
                {
                    View.SetImageCopy(ImageContainer.Destination, new Bitmap(image));
                    View.SetImageToZoom(ImageContainer.Destination, new Bitmap(image));
                    View.AddToUndoContainer((new Bitmap(image), ImageContainer.Source));

                    return (Bitmap)View.GetImageCopy(ImageContainer.Destination).Clone();
                });

                _pipeline.Register(block);

                await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
            }
            catch (OperationCanceledException cancelEx)
            {
                View.ShowError("The operation has been canceled.");
            }
            catch (Exception ex)
            {
                View.ShowError($"Error {ex.Message}");
            }
        }

        private async Task ApplyHistogramTransformation(DistributionEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var filter = _distributionFactory
                        .GetFilter(e.Arg)
                        .SetParams(e.Parameters);

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    var block = new PipelineBlock<Bitmap>(copy);

                    block.Add<Bitmap, Bitmap>((image) => _distributionService.TransformTo(image, filter));

                    block.Add<Bitmap, Bitmap>((bmp) =>
                    {
                        View.SetImageCopy(ImageContainer.Destination, new Bitmap(bmp));
                        View.SetImageToZoom(ImageContainer.Destination, new Bitmap(bmp));
                        View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                        return (Bitmap)View.GetImageCopy(ImageContainer.Destination).Clone();
                    });

                    _pipeline.Register(block);

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);

                    View.DstImage.Tag = filter.Name;
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

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    var block = new PipelineBlock<Bitmap>(copy);

                    block.Add<Bitmap, Bitmap>((bmp) => bmp.Shuffle());

                    block.Add<Bitmap, Bitmap>((bmp) =>
                    {
                        View.SetImageCopy(ImageContainer.Destination, new Bitmap(bmp));
                        View.SetImageToZoom(ImageContainer.Destination, new Bitmap(bmp));
                        View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                        return (Bitmap)View.GetImageCopy(ImageContainer.Destination).Clone();
                    });

                    _pipeline.Register(block);

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
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
                        new HistogramViewModel(new Bitmap(await GetImageCopy(e.Arg).ConfigureAwait(true)), e.Action)
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

                var replaceFrom = e.Arg;

                if (!View.ImageIsNull(replaceFrom))
                {
                    var replaceTo = replaceFrom == ImageContainer.Source ?
                      ImageContainer.Destination : ImageContainer.Source;

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(replaceFrom).ConfigureAwait(true);

                    var block = new PipelineBlock<Bitmap>(copy);

                    block.Add<Bitmap, Bitmap>((bmp) =>
                    {
                        View.SetImageCopy(replaceTo, new Bitmap(bmp));
                        View.SetImageToZoom(replaceTo, new Bitmap(bmp));
                        View.AddToUndoContainer((new Bitmap(bmp), replaceFrom));

                        return (Bitmap)View.GetImageCopy(replaceTo).Clone();
                    });

                    _pipeline.Register(block);

                    await UpdateContainer(replaceTo).ConfigureAwait(true);
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
        }

        private async Task GetRandomVariableInfo(RandomVariableEventArgs e)
        {
            try
            {
                Requires.IsNotNull(e, nameof(e));

                var container = e.Arg;

                if (!View.ImageIsNull(container))
                {
                    var copy = await GetImageCopy(container);

                    var result = await Task.Run(() =>
                    {
                        switch (e.Action)
                        {
                            case RandomVariable.Expectation:
                                return _distributionService.GetExpectation(copy).ToString();
                            case RandomVariable.Variance:
                                return _distributionService.GetVariance(copy).ToString();
                            case RandomVariable.StandardDeviation:
                                return _distributionService.GetStandardDeviation(copy).ToString();
                            case RandomVariable.Entropy:
                                return _distributionService.GetEntropy(copy).ToString();
                        }

                        throw new NotImplementedException(nameof(e.Action));

                    }).ConfigureAwait(true);

                    View.ShowInfo(result);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Error while getting the information about {nameof(e.Action).ToLower()}.");
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


        private async Task<Bitmap> GetImageCopy(ImageContainer container)
        {
            return await _operationLocker.LockAsync(() =>
                  new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);
        }

        private async Task UpdateContainer(ImageContainer container)
        {
            var result = await _pipeline.AwaitResult().ConfigureAwait(true);

            View.SetImage(container, result);
            View.Refresh(container);
            View.ResetTrackBarValue(container);

            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
        }

        private void CloseForm()
        {
            _staTaskService.Dispose();
        }
    }
}
