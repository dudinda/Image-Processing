using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Configuration;

using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.DomainModel.Services.ConvolutionFilter;
using ImageProcessing.DomainModel.Services.Distribution;
using ImageProcessing.DomainModel.Services.RGBFilter;
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

namespace ImageProcessing.Presentation.Presenters.Main
{
    public partial class MainPresenter : BasePresenter<IMainView>
    {
        private static readonly AsyncLocker _locker = new AsyncLocker();

        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;

        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IDistributionFactory _distributionFactory;
        private readonly IRGBFiltersFactory _rgbFiltersFactory;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IBaseFactory baseFactory,
                             IConvolutionFilterService convolutionFilterService,
                             IDistributionService distributionService,
                             IRGBFilterService rgbFilterService) : base(controller, view)
        {
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
                var openFileDialog = new OpenFileDialog()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    Filter = ConfigurationManager.AppSettings["Filters"]
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    View.SrcImage = await Task.Run(() =>
                    {
                        using (var stream = File.OpenRead(openFileDialog.FileName))
                        {
                            return new Bitmap(Image.FromStream(stream));
                        }

                    });
                    View.PathToFile = openFileDialog.FileName;
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
                var saveFileDialog = new SaveFileDialog()
                {
                    Filter = ConfigurationManager.AppSettings["Filters"]
                };
               
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await _locker.LockAsync(() =>
                    {
                        var bmpToSave = new Bitmap(View.SrcImage);
                        var extension = Path.GetExtension(saveFileDialog.FileName);
                        bmpToSave.Save(saveFileDialog.FileName, extension.GetImageFormat());
                    });
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
                });            
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
                );
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
                );
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
                }
      
                if (result == RGBColors.Unknown)
                {
                    View.DstImage = View.SrcImage;
                    return;
                }

                var filter = _rgbFiltersFactory.GetColorFilter(result);

                View.DstImage = await _locker.LockAsync(
                    () => filter.Filter(new Bitmap(View.SrcImage))
                );
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
                    () => _distributionService.Distribute(new Bitmap(View.SrcImage), filter)
                );
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
                );
            }
            catch
            {
                View.ShowError("Error while shuffling the image.");
            }
        }

        private void BuildPMF(string target)
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

        private void BuildCDF(string target)
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
                }

                throw new ArgumentException();
            }
            catch
            {
                View.ShowError("Error while replacing the image.");
            }
        }
    }
}
