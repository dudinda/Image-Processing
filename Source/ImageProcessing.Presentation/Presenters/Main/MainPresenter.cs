using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Configuration;

using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Factory.Base;
using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.DomainModel.Factory.Filters.Interface;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.TupleExtensions;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Core.AppController.Interface;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Services.RGBFilterService.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;

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

            if(baseFactory is null)  throw new ArgumentNullException(nameof(baseFactory));

            _convolutionFilterFactory = baseFactory.GetConvolutionFilterFactory();
            _distributionFactory      = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory        = baseFactory.GetRGBFilterFactory();

            _convolutionFilterService = convolutionFilterService;
            _rgbFilterService         = rgbFilterService;
            _distributionService      = distributionService;

            Bind();
        }

        private async void OpenImage()
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        View.SrcImage = await Task.Run(() =>
                        {
                            using (var stream = File.OpenRead(dialog.FileName))
                            {
                                return new Bitmap(Image.FromStream(stream));
                            }

                        }).ConfigureAwait(false);

                        View.PathToFile = dialog.FileName;
                    }
                }
            }
            catch
            {
                View.ShowError("Error while opening the file.");
            }
        }

        private async void SaveImageAs()
        {
            try
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = ConfigurationManager.AppSettings["Filters"];

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        await _locker.LockAsync(() =>
                        {
                            var bmpToSave = new Bitmap(View.SrcImage);
                            var extension = Path.GetExtension(dialog.FileName);
                            bmpToSave.Save(dialog.FileName, extension.GetImageFormat());
                        }).ConfigureAwait(true);
                    }
                }
            }
            catch
            {
                View.ShowError("Error while saving the file.");
            }
        }

        private async void SaveImage()
        {
            try
            {
                await _locker.LockAsync(() =>
                {
                    var bmpToSave = new Bitmap(View.SrcImage);
                    var extension = Path.GetExtension(View.PathToFile);
                    bmpToSave.Save(View.PathToFile, extension.GetImageFormat());
                }).ConfigureAwait(true);            
            }
            catch
            {
                View.ShowError("Error while saving the file.");
            }
        }

        private async void ApplyConvolutionFilter(string filterName)
        {
            try
            {
                if (View.SrcIsNull) return; 

                var filter = _convolutionFilterFactory.GetFilter(filterName);
             
                View.DstImage = await _locker.LockAsync(
                    () => _convolutionFilterService.Convolution(new Bitmap(View.SrcImage), filter)
                ).ConfigureAwait(true);
            }
            catch 
            {
                View.ShowError("Error while applying a convolution filter.");
            }
        }

        private async void ApplyRGBFilter(string filterName)
        {
            try
            {
                if (View.SrcIsNull) return; 

                var filter = _rgbFiltersFactory.GetFilter(filterName);

                View.DstImage = await _locker.LockAsync(
                    () => _rgbFilterService.Filter(new Bitmap(View.SrcImage), filter)
                ).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while applying RGB filter.");
            }
        }

        private async void ApplyColorFilter(string filterName)
        {
            try
            {
                if (View.SrcIsNull) return;

                RGBColors result = default;

                switch (filterName.GetEnumValueByName<RGBColors>())
                {
                    case RGBColors.Red:
                        View.IsRedChannelChecked = !View.IsRedChannelChecked;
                        if(View.IsRedChannelChecked) result |= RGBColors.Red;
                        break;

                    case RGBColors.Blue:
                        View.IsBlueChannelChecked = !View.IsBlueChannelChecked;
                        if(View.IsBlueChannelChecked) result |= RGBColors.Blue;
                        break;

                    case RGBColors.Green:
                        View.IsGreenChannelChecked = !View.IsGreenChannelChecked;
                        if(View.IsGreenChannelChecked) result |= RGBColors.Green;
                        break;

                    default: throw new NotSupportedException(nameof(filterName));
                }
      
                if (result == RGBColors.Unknown)
                {
                    View.DstImage = View.SrcImage;
                    return;
                }

                var filter = _rgbFiltersFactory.GetColorFilter(result);

                View.DstImage = await _locker.LockAsync(
                    () => filter.Filter(new Bitmap(View.SrcImage))
                ).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while applying the filter by RGB channel.");
            }
        }  

        private async void ApplyHistogramTransformation(string filterName, (string, string) parms)
        {
            try
            {
                if (View.SrcIsNull) return; 

                var filter = _distributionFactory.GetFilter(filterName);

                if (!parms.TryParse<double, double>(out var result))
                    return;

                filter.SetParams(result);

                View.DstImage  = await _locker.LockAsync(
                    () => _distributionService.TransformTo(new Bitmap(View.SrcImage), filter)
                ).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while applying histogram transformation.");
            }
        }

        private async void Shuffle()
        {
            try
            {
                if (View.SrcIsNull) return; 

                View.DstImage = await _locker.LockAsync(
                   () => new Bitmap(View.SrcImage).Shuffle()
                ).ConfigureAwait(true);
            }
            catch
            {
                View.ShowError("Error while shuffling the image.");
            }
        }

        private void BuildPMF(string target)
        { 
            try
            {
                switch (target.GetEnumValueByName<ImageContainer>())
                {
                    case ImageContainer.Source:
                        if (View.SrcIsNull) return;
                        Controller.Run<HistogramPresenter, HistogramViewModel>(
                            new HistogramViewModel(new Bitmap(View.SrcImage), RandomVariableAction.PMF)
                        );
                        break;

                    case ImageContainer.Destination:
                        if (View.DstIsNull) return;
                        Controller.Run<HistogramPresenter, HistogramViewModel>(
                            new HistogramViewModel(new Bitmap(View.DstImage), RandomVariableAction.PMF)
                        );
                        break;
                }
            }
            catch
            {
                View.ShowError("Error while buiding the PMF of the image.");
            }
        }

        private void BuildCDF(string target)
        {
            try
            {
                switch (target.GetEnumValueByName<ImageContainer>())
                {
                    case ImageContainer.Source:
                        if (View.SrcIsNull) return;
                        Controller.Run<HistogramPresenter, HistogramViewModel>(
                            new HistogramViewModel(new Bitmap(View.SrcImage), RandomVariableAction.CDF)
                        );
                        break;

                    case ImageContainer.Destination:
                        if (View.DstIsNull) return;
                        Controller.Run<HistogramPresenter, HistogramViewModel>(
                            new HistogramViewModel(new Bitmap(View.DstImage), RandomVariableAction.CDF)
                        );
                        break;

                    default: throw new NotSupportedException(nameof(target));
                }
            }
            catch
            {
                View.ShowError("Error while buiding the CDF of the image.");
            }
        }

        private void Replace(string target)
        {
            try
            {
                switch(target.GetEnumValueByName<ImageContainer>())
                {
                    case ImageContainer.Source:
                        if (View.DstIsNull) return;
                        View.SrcImage = View.DstImage;
                        break;

                    case ImageContainer.Destination:
                        if (View.SrcIsNull) return;
                        View.DstImage = View.SrcImage;
                        break;

                    default: throw new NotSupportedException(nameof(target));
                }
            }
            catch
            {
                View.ShowError("Error while replacing the image.");
            }
        }
    }
}
