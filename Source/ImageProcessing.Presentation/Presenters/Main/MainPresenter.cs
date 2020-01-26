using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Extensions.TupleExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.Convolution;
using ImageProcessing.Core.Factory.Distribution;
using ImageProcessing.Core.Factory.RGBFilters;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Presentation.Code.Singletons;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.RGBFilterService.Interface;

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

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IBaseFactory baseFactory,
                             IConvolutionFilterService convolutionFilterService,
                             IBitmapLuminanceDistributionService distributionService,
                             IRGBFilterService rgbFilterService) : base(controller, view)
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

            Bind();
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
                if (View.ImageIsNull(ImageContainer.Source)) return;

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        View.SetCursor(CursorType.WaitCursor);
                        
                        await OperationLocker.Get().LockOperation(() =>
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
                if (View.ImageIsNull(ImageContainer.Source)) return;

                View.SetCursor(CursorType.WaitCursor);

                await OperationLocker.Get().LockOperation(() =>
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

        private async Task ApplyConvolutionFilter(string filterName)
        {
            try
            {
                Requires.IsNotNull(filterName, nameof(filterName));

                if (View.ImageIsNull(ImageContainer.Source)) return; 

                var filter = _convolutionFilterFactory.GetFilter(filterName);
                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                OperationPipeline.Instance.Register(() =>
                {
                    var filteredResult = _convolutionFilterService.Convolution(new Bitmap(copy), filter);
                    View.DstImageCopy = (Bitmap)filteredResult.Clone();
                    View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));
                    View.SetImageToZoom(ImageContainer.Destination, new Bitmap(filteredResult));

                    return (Bitmap)filteredResult.Clone();
                });

                await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
            }
            catch 
            {
                View.ShowError("Error while applying a convolution filter.");
            }
        }

        private async Task ApplyRGBFilter(string filterName)
        {
            try
            {
                Requires.IsNotNull(filterName, nameof(filterName));

                if (View.ImageIsNull(ImageContainer.Source)) return; 

                var filter = _rgbFiltersFactory.GetFilter(filterName);
                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                OperationPipeline.Instance.Register(() =>  
                {
                    var filteredResult = _rgbFilterService.Filter(new Bitmap(copy), filter);
                    View.DstImageCopy = new Bitmap(filteredResult);
                    View.SetImageToZoom(ImageContainer.Destination, new Bitmap(filteredResult));
                    View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                    return (Bitmap)filteredResult.Clone();
                });

                await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while applying an RGB filter.");
            }
        }

        private async Task ApplyColorFilter(string filterName)
        {
            try
            {
                Requires.IsNotNull(filterName, nameof(filterName));

                if (View.ImageIsNull(ImageContainer.Source)) return;

                var color = filterName.GetEnumValueByName<RGBColors>();
                var result = View.GetSelectedColors(color);
      
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

        private async Task ApplyHistogramTransformation(string filterName, (string, string) parms)
        {
            try
            {
                if (View.ImageIsNull(ImageContainer.Source)) return; 

                if (parms.TryParse<decimal, decimal>(out var result))
                {
                    var filter = _distributionFactory
                        .GetFilter(filterName)
                        .SetParams(result);

                    View.SetCursor(CursorType.WaitCursor);

                    var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                    OperationPipeline.Instance.Register(() =>
                    {
                        var filterResult = _distributionService.TransformTo(new Bitmap(copy), filter);
                        View.DstImageCopy = new Bitmap(filterResult);
                        View.SetImageToZoom(ImageContainer.Destination, new Bitmap(filterResult));
                        View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                        return (Bitmap)View.DstImageCopy.Clone();
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
                if (View.ImageIsNull(ImageContainer.Source)) return;

                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(ImageContainer.Source).ConfigureAwait(true);

                OperationPipeline.Instance.Register(() =>
                {
                    var filteredResult = new Bitmap(copy).Shuffle();
                    View.DstImageCopy = (Bitmap)filteredResult.Clone();
                    View.SetImageToZoom(ImageContainer.Destination, new Bitmap(filteredResult));
                    View.AddToUndoContainer((new Bitmap(copy), ImageContainer.Source));

                    return (Bitmap)View.DstImageCopy.Clone();
                });

                await UpdateContainer(ImageContainer.Destination).ConfigureAwait(true);   
            }
            catch
            {
                View.ShowError("Error while shuffling the image.");
            }
        }

        private void BuildFunction(string containerType, string functionType)
        {
            try
            {
                Requires.IsNotNull(containerType, nameof(containerType));
                Requires.IsNotNull(functionType, nameof(functionType));

                var function  = functionType.GetEnumValueByName<RandomVariable>();
                var container = containerType.GetEnumValueByName<ImageContainer>();

                if (!View.ImageIsNull(container))
                {
                    Controller.Run<HistogramPresenter, HistogramViewModel>(
                        new HistogramViewModel(new Bitmap(View.GetImageCopy(container)), function)
                    );
                }
            }
            catch
            {
                View.ShowError($"Error while buiding the plot.");
            }
        }
     
        private async Task Replace(string replaceFrom)
        {
            try
            {
                Requires.IsNotNull(replaceFrom, nameof(replaceFrom));

                var source = replaceFrom.GetEnumValueByName<ImageContainer>();

                var target = source == ImageContainer.Source ?
                    ImageContainer.Destination : ImageContainer.Source;

                if (View.ImageIsNull(source)) return;

                View.SetCursor(CursorType.WaitCursor);

                var copy = await GetImageCopy(source).ConfigureAwait(true);

                OperationPipeline.Instance.Register(() =>
                {
                    View.SetImageCopy(target, new Bitmap(copy));
                    View.SetImageToZoom(target, new Bitmap(View.GetImageCopy(target)));
                    View.AddToUndoContainer((new Bitmap(copy), source));

                    return (Bitmap)View.GetImageCopy(target).Clone();
                });

                await UpdateContainer(target).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while replacing the image.");
            }
        }

        private async Task GetRandomVariableInfo(string containerType, string actionType)
        {
            try
            {
                Requires.IsNotNull(actionType, nameof(actionType));
                Requires.IsNotNull(containerType, nameof(containerType));

                var container = containerType.GetEnumValueByName<ImageContainer>();
                var action = actionType.GetEnumValueByName<RandomVariable>();

                if (View.ImageIsNull(container)) return;


                var copy = await GetImageCopy(ImageContainer.Source);

                var result = await Task.Run(() =>
                {
                    switch(action)
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
            catch
            {

            }
        }

        private async Task Zoom(string target)
        {
            try
            {
                Requires.IsNotNull(target, nameof(target));

                var container = target.GetEnumValueByName<ImageContainer>();

                if (!View.ImageIsNull(container)) {
      
                    var image = await ZoomLocker.Get().LockZoom(() =>
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
            return await OperationLocker.Get().LockOperation(() =>
                  new Bitmap(View.GetImageCopy(container))
            ).ConfigureAwait(true);
        }

        private async Task UpdateContainer(ImageContainer container)
        {
            var result = await OperationPipeline.Instance
                          .GetFirstCompleted().ConfigureAwait(true);

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
