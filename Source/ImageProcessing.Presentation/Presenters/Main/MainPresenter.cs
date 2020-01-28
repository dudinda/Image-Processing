using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Extensions.FuncExtensions;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Extensions.TupleExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Presentation.Code.Singletons;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.RGBFilterService.Interface;

using LightInject;

namespace ImageProcessing.Presentation.Presenters.Main
{
    public partial class MainPresenter : BasePresenter<IMainView>
    {

        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IBitmapLuminanceDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;

        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IDistributionFactory _distributionFactory;
        private readonly IRGBFiltersFactory _rgbFiltersFactory;

        private readonly IEventAggregator _eventAggregator;

        private readonly IAsyncLocker _zoomLocker;
        private readonly IAsyncLocker _operationLocker;
        
        public MainPresenter(IAppController controller,
                             IMainView view,
                             IBaseFactory baseFactory,
                             IConvolutionFilterService convolutionFilterService,
                             IBitmapLuminanceDistributionService distributionService,
                             IRGBFilterService rgbFilterService,
                             IEventAggregator eventAggregator,

                             [Inject("ZoomLocker")]
                             IAsyncLocker zoomLocker,

                             [Inject("OperationLocker")]
                             IAsyncLocker operationLocker) : base(controller, view)
        {
            Requires.IsNotNull(controller, nameof(controller));
            Requires.IsNotNull(view, nameof(view));
            Requires.IsNotNull(baseFactory, nameof(baseFactory));
                              
            _convolutionFilterFactory = baseFactory.GetConvolutionFilterFactory();
            _distributionFactory      = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory        = baseFactory.GetRGBFilterFactory();

            _convolutionFilterService = Requires.IsNotNull(convolutionFilterService, nameof(convolutionFilterService));
            _rgbFilterService         = Requires.IsNotNull(rgbFilterService, nameof(rgbFilterService));
            _distributionService      = Requires.IsNotNull(distributionService, nameof(distributionService)); ;

            _eventAggregator          = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));

            _zoomLocker               = Requires.IsNotNull(zoomLocker, nameof(zoomLocker));
            _operationLocker          = Requires.IsNotNull(operationLocker, nameof(operationLocker));

            _eventAggregator.Subscribe(this);
        }

        private async Task OpenImage()
        {
            try
            {           
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        View.SetCursor(CursorType.WaitCursor);

                        View.SrcImage = await Task.Run(() =>
                        {
                            using (var stream = File.OpenRead(dialog.FileName))
                            {
                                View.SrcImageCopy = new Bitmap(Image.FromStream(stream));
                            }

                            View.SetImageToZoom(ImageContainer.Source, new Bitmap(View.SrcImageCopy));
       
                            return (Bitmap)View.SrcImageCopy.Clone();
                        }).ConfigureAwait(true);

                        View.Refresh(ImageContainer.Destination);
                        View.SetCursor(CursorType.Default);
                        View.ResetTrackBarValue(ImageContainer.Source);
                        View.PathToFile = dialog.FileName;
                        
                    }
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
                if (View.ImageIsNull(ImageContainer.Source)) { return; }

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        View.SetCursor(CursorType.WaitCursor);
                        
                        await _operationLocker.LockAsync(() =>
                        {
                            var extension = Path.GetExtension(dialog.FileName);

                            new Bitmap(View.SrcImageCopy)
                            .Save(dialog.FileName, extension.GetImageFormat());
                        }).ConfigureAwait(true);

                        View.SetCursor(CursorType.Default);
                    }
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
                if (View.ImageIsNull(ImageContainer.Source)) { return; }

                View.SetCursor(CursorType.WaitCursor);

                await _operationLocker.LockAsync(() =>
                {
                    var extension = Path.GetExtension(View.PathToFile);

                    new Bitmap(View.SrcImageCopy)
                    .Save(View.PathToFile, extension.GetImageFormat());
                }).ConfigureAwait(true);

                View.SetCursor(CursorType.Default);
            }
            catch
            {
                View.ShowError("Error while saving the file.");
            }
        }

        private async Task ApplyConvolutionFilter(ConvolutionFilter filter)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    OperationPipeline.Instance.Register(() =>
                    {
                        return copy.Process(_convolutionFilterFactory.GetFilter(filter), _convolutionFilterService.Convolution)
                                   .Process(() => View.SetImageCopy(ImageContainer.Destination, (Bitmap)copy.Clone()))
                                   .Process(() => View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source)))
                                   .Process(() => View.SetImageToZoom(ImageContainer.Destination, new Bitmap(copy)))
                                   .Process((arg) => (Bitmap)arg.Clone());
                    });

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
                }
            }
            catch 
            {
                View.ShowError("Error while applying a convolution filter.");
            }
        }

        private async Task ApplyRGBFilter(RGBFilter filter)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    OperationPipeline.Instance.Register(() =>
                    {
                        return copy.Process(_rgbFiltersFactory.GetFilter(filter), _rgbFilterService.Filter)
                                   .Process(() => View.DstImageCopy = new Bitmap(copy))
                                   .Process(() => View.SetImageToZoom(ImageContainer.Destination, new Bitmap(copy)))
                                   .Process(() => View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source)))
                                   .Process((arg) => (Bitmap)arg.Clone());
                    });

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
                }
            }
            catch
            {
                View.ShowError("Error while applying an RGB filter.");
            }
        }

        private async Task ApplyColorFilter(RGBColors filter)
        {
            try
            {

                if (View.ImageIsNull(ImageContainer.Source)) { return; }

                var result = View.GetSelectedColors(filter);
      
                if (result is default(RGBColors))
                {
                    View.DstImage = View.SrcImage;
                    return;
                }

                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                OperationPipeline.Instance.Register(() =>
                {
                    var filterResult =  _rgbFiltersFactory.GetColorFilter(result).Filter(new Bitmap(View.SrcImageCopy));
                    View.DstImageCopy = new Bitmap(filterResult);
                    View.SetImageToZoom(ImageContainer.Destination, new Bitmap(filterResult));
                    View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                    return (Bitmap)View.DstImageCopy.Clone();
                });

                await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
            }
            catch(Exception ex)
            {
                View.ShowError($"Error {ex.Message}");
            }
        }

        private async Task ApplyHistogramTransformation(Distribution distribution, (decimal, decimal) parms)
        {
            try
            {
                if (!View.ImageIsNull(ImageContainer.Source))
                {
                    var filter = _distributionFactory
                        .GetFilter(distribution)
                        .SetParams(parms);

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    OperationPipeline.Instance.Register(() =>
                    {
                        return copy.Process(filter, _distributionService.TransformTo)
                                   .Process(() => View.DstImageCopy = new Bitmap(copy))
                                   .Process(() => View.SetImageToZoom(ImageContainer.Destination, new Bitmap(copy)))
                                   .Process(() => View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source)))
                                   .Process((arg) => (Bitmap)arg.Clone());
                    });

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);

                    View.DstImage.Tag = filter.Name;
                }

            }
            catch
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

                    OperationPipeline.Instance.Register(() =>
                    {
                        return copy.Shuffle()
                                   .Process(() => View.DstImageCopy = new Bitmap(copy))
                                   .Process(() => View.SetImageToZoom(ImageContainer.Destination, new Bitmap(copy)))
                                   .Process(() => View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source)))
                                   .Process((arg) => (Bitmap)arg.Clone());
                    });

                    await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
                }
            }
            catch
            {
                View.ShowError("Error while shuffling the image.");
            }
        }

        private void BuildFunction(ImageContainer container, RandomVariable action)
        {
            try
            {
                if (!View.ImageIsNull(container))
                {
                    Controller.Run<HistogramPresenter, HistogramViewModel>(
                        new HistogramViewModel(new Bitmap(View.GetImageCopy(container)), action)
                    );
                }
            }
            catch
            {
                View.ShowError($"Error while buiding the plot.");
            }
        }
     
        private async Task Replace(ImageContainer replaceFrom)
        {
            try
            {
                if (!View.ImageIsNull(replaceFrom))
                {
                    var replaceTo = replaceFrom == ImageContainer.Source ?
                      ImageContainer.Destination : ImageContainer.Source;

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(replaceFrom).ConfigureAwait(true);

                    OperationPipeline.Instance.Register(() =>
                    {
                        return copy.Process(() => View.SetImageCopy(replaceTo, new Bitmap(copy)))
                                   .Process(() => View.SetImageToZoom(replaceTo, new Bitmap(View.GetImageCopy(replaceTo))))
                                   .Process(() => View.AddToUndoContainer((new Bitmap(copy), replaceFrom)))
                                   .Process((arg) => (Bitmap)View.GetImageCopy(replaceTo).Clone());
                    });

                    await UpdateContainer(replaceTo).ConfigureAwait(true);
                }
            }
            catch
            {
                View.ShowError("Error while replacing the image.");
            }
        }

        private async Task GetRandomVariableInfo(ImageContainer container, RandomVariable action)
        {
            try
            {

                if (!View.ImageIsNull(container))
                {
                    var copy = await GetImageCopy(ImageContainer.Source);

                    var result = await Task.Run(() =>
                    {
                        switch (action)
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

                        throw new NotImplementedException(nameof(action));

                    }).ConfigureAwait(true);

                    View.ShowInfo(result);
                }
            }
            catch
            {

            }
        }

        private async Task Zoom(ImageContainer container)
        {
            try
            {
                if (!View.ImageIsNull(container)) {
      
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
            var result = await OperationPipeline.Instance
                          .GetCompleted().ConfigureAwait(true);

            View.SetImage(container, result);
            View.Refresh(container);
            View.ResetTrackBarValue(container);

            if (OperationPipeline.Instance.IsEmpty)
            {
                View.SetCursor(CursorType.Default);
            }
        }
    }
}
