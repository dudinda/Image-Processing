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
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.RGBFilterService.Interface;

namespace ImageProcessing.Presentation.Presenters.Main
{
    public partial class MainPresenter : BasePresenter<IMainView>
    {
        private static readonly AsyncLocker _locker = new AsyncLocker();

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

                            View.SetTrackBarSize(ImageContainer.Source, View.SrcImageCopy.Size);
       
                            return new Bitmap(View.SrcImageCopy);
                        }).ConfigureAwait(true);
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
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        View.SetCursor(CursorType.WaitCursor);
                        await _locker.LockAsync(() =>
                        {
                            var bmpToSave = new Bitmap(View.SrcImage);
                            var extension = Path.GetExtension(dialog.FileName);
                            bmpToSave.Save(dialog.FileName, extension.GetImageFormat());

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
                View.SetCursor(CursorType.WaitCursor);
                await _locker.LockAsync(() =>
                {
                    var bmpToSave = new Bitmap(View.SrcImage);
                    var extension = Path.GetExtension(View.PathToFile);
                    bmpToSave.Save(View.PathToFile, extension.GetImageFormat());

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

                if (View.ImageIsNull(ImageContainer.Source)) 
                    return; 

                var filter = _convolutionFilterFactory.GetFilter(filterName);
                View.SetCursor(CursorType.WaitCursor);
                View.DstImage = await _locker.LockAsync(() =>
                {
                    View.DstImageCopy = _convolutionFilterService
                    .Convolution(
                        new Bitmap(View.GetImage(ImageContainer.Source)), filter
                        );

                    View.SetTrackBarSize(ImageContainer.Destination, View.DstImageCopy.Size);

                    return new Bitmap(View.DstImageCopy);
                }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
                View.ResetTrackBarValue(ImageContainer.Destination);
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

                if (View.ImageIsNull(ImageContainer.Source)) 
                    return; 

                var filter = _rgbFiltersFactory.GetFilter(filterName);
                View.SetCursor(CursorType.WaitCursor);
                View.DstImage = await _locker.LockAsync(() =>
                {
                    View.DstImageCopy = _rgbFilterService.Filter(new Bitmap(View.SrcImage), filter);
                    View.SetTrackBarSize(ImageContainer.Destination, View.DstImageCopy.Size);

                    return new Bitmap(View.DstImageCopy);
                }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
                View.ResetTrackBarValue(ImageContainer.Destination);
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

                if (View.ImageIsNull(ImageContainer.Source)) 
                    return;

                var color = filterName.GetEnumValueByName<RGBColors>();

                var result = View.GetSelectedColors(color);
      
                if (result is default(RGBColors))
                {
                    View.DstImage = View.SrcImage;
                    return;
                }

                View.SetCursor(CursorType.WaitCursor);
                View.DstImage = await _locker.LockAsync(
                    () =>
                    {
                        View.DstImageCopy = _rgbFiltersFactory
                        .GetColorFilter(result)
                        .Filter(new Bitmap(View.SrcImage));

                        View.SetTrackBarSize(ImageContainer.Destination, View.DstImageCopy.Size);

                        return new Bitmap(View.DstImageCopy);
                    }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
                View.ResetTrackBarValue(ImageContainer.Destination);
            }
            catch
            {
                View.ShowError("Error while applying the filter by RGB channel.");
            }
        }  

        private async Task ApplyHistogramTransformation(string filterName, (string, string) parms)
        {
            try
            {
                if (View.ImageIsNull(ImageContainer.Source))  
                    return; 

                if (parms.TryParse<decimal, decimal>(out var result))
                {
                    var filter = _distributionFactory
                        .GetFilter(filterName)
                        .SetParams(result);

                    View.SetCursor(CursorType.WaitCursor);
                    View.DstImage = await _locker.LockAsync(
                        () =>
                        {
                            View.DstImageCopy = _distributionService.TransformTo(new Bitmap(View.SrcImage), filter);
                            View.SetTrackBarSize(ImageContainer.Destination, View.DstImageCopy.Size);
                            return new Bitmap(View.DstImageCopy);
                        }
                    ).ConfigureAwait(true);
                    View.SetCursor(CursorType.Default);
                    View.ResetTrackBarValue(ImageContainer.Destination);
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
                View.DstImage = await _locker.LockAsync(
                   () => 
                   {
                       View.DstImageCopy = new Bitmap(View.SrcImage).Shuffle();
                       View.SetTrackBarSize(ImageContainer.Destination, View.DstImageCopy.Size);

                       return new Bitmap(View.DstImageCopy);
                   }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
                View.ResetTrackBarValue(ImageContainer.Destination);
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
                        new HistogramViewModel(new Bitmap(View.GetImage(container)), function)
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
                var result = await _locker.LockAsync(() =>
                {
                    View.SetImageCopy(target, (Image)View.GetImageCopy(source).Clone());
                    View.SetTrackBarSize(target, View.GetImageCopySize(source));
                    
                    return new Bitmap(View.GetImageCopy(target));
                }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
                View.ResetTrackBarValue(target);
                View.SetImage(target, result);
            }
            catch
            {
                View.ShowError("Error while replacing the image.");
            }
        }

        private async Task GetRandomVariableInfo(string action)
        {
            try
            {
                Requires.IsNotNull(action, nameof(action));

                View.SetCursor(CursorType.WaitCursor);
                await _locker.LockAsync(() =>
                {
                    var image = new Bitmap(View.SrcImageCopy);

                    switch(action.GetEnumValueByName<RandomVariable>())
                    {
                        case RandomVariable.Expectation:
                            View.ShowInfo(_distributionService.GetExpectation(image).ToString());
                            break;
                        case RandomVariable.Variance:
                            View.ShowInfo(_distributionService.GetVariance(image).ToString());
                            break;
                        case RandomVariable.StandardDeviation:
                            View.ShowInfo(_distributionService.GetStandardDeviation(image).ToString());
                            break;
                        case RandomVariable.Entropy:
                            View.ShowInfo(_distributionService.GetEntropy(image).ToString());
                            break;
                    }
                }).ConfigureAwait(true);
                View.SetCursor(CursorType.Default);
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
                    View.SetCursor(CursorType.WaitCursor);
                    var result = await _locker.LockAsync(
                        () => new Bitmap(View.GetImageCopy(container), View.GetZoomFactor(container))
                        ).ConfigureAwait(true);
                    View.SetCursor(CursorType.Default);
                    View.SetImage(container, result);
                }              
            }
            catch
            {
                View.ShowError("Error while zooming the image.");
            }
        }
    }
}
