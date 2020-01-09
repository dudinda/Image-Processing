using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.AppController;
using ImageProcessing.DomainModel.Services.ConvolutionFilter;
using ImageProcessing.DomainModel.Services.Distribution;
using ImageProcessing.DomainModel.Services.RGBFilter;
using ImageProcessing.Factory.Base;
using ImageProcessing.DomainModel.Factory.Filters.Interface;
using ImageProcessing.Common.Extensions.StringExtensions;
using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Extensions.TupleExtensions;

using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Configuration;

namespace ImageProcessing.Presentation.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IConvolutionFilterService _convolutionFilterService;
        private readonly IDistributionService _distributionService;
        private readonly IRGBFilterService _rgbFilterService;

        private readonly IConvolutionFilterFactory _convolutionFilterFactory;
        private readonly IDistributionFactory _distributionFactory;
        private readonly IRGBFiltersFactory _rgbFiltersFactory;

        public MainPresenter(IAppController controller,
                             IMainView view,
                             IBaseFactory baseFactory) : base(controller, view)
        {
            _convolutionFilterFactory = baseFactory.GetConvolutionFilterFactory();
            _distributionFactory      = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory        = baseFactory.GetRGBFilterFactory();

            View.ApplyConvolutionFilter       += (filter) => ApplyConvolutionFilter(filter);
            View.ApplyRGBFilter               += (filter) => ApplyRGBFilter(filter);
            View.ApplyHistogramTransformation += (distribution, parms) => ApplyHistogramTransformation(distribution, parms);
            View.SaveImage                    += () => SaveImage();
            View.OpenImage                    += (filename) => OpenImage(filename);
            View.Shuffle                      += () => Shuffle();

        }

        private async void OpenImage(string fileName)
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
                    View.InitSrcImageZoom();
                    View.Path = openFileDialog.FileName;
                }            
            }
            catch
            {
                View.ShowError("Error while opening the file.");
            }
        }

        private async void SaveImage()
        {
            try
            {
                var saveFileDialog = new SaveFileDialog()
                {
                    Filter = ConfigurationManager.AppSettings["Filters"]
                };

                var bmpToSave = new Bitmap(View.SrcImage);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await Task.Run(() =>
                    {
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

        private async void ApplyConvolutionFilter(string filterName)
        {
            try
            {
                if (View.SrcIsNull) { return; }

                var filter = _convolutionFilterFactory.GetFilter(filterName);

                View.DstImage = await Task.Run(() => _convolutionFilterService.Convolution(View.SrcImage, filter));
                View.InitDstImageZoom();
            }
            catch(Exception ex)
            {
                View.ShowError("Error while applying a convolution filter.");
            }
        }

        private async void ApplyRGBFilter(string filterName)
        {
            try
            {
                if (View.SrcIsNull) { return; }

                var filter = _rgbFiltersFactory.GetFilter(filterName);

                View.DstImage = await Task.Run(() => _rgbFilterService.Filter(View.SrcImage, filter));
                View.InitDstImageZoom();
            }
            catch(Exception ex)
            {
                View.ShowError("Error while applying RGB filter.");
            }
        }

        private async void ApplyHistogramTransformation(string filterName, (string, string) parms)
        {
            try
            {
                if (View.SrcIsNull) { return; }

                var filter = _distributionFactory.GetFilter(filterName);

                if (!parms.TryParse<double, double>(out var result))
                {
                    return;
                }

                filter.SetParams(result);

                View.DstImage = await Task.Run(() => _distributionService.Distribute(View.SrcImage, filter));
                View.InitDstImageZoom();
            }
            catch(Exception ex)
            {
                View.ShowError("Error while applying histogram transformation.");
            }
        }

        private async void Shuffle()
        {
            try
            {
                if (View.SrcIsNull) { return; }

                View.DstImage = await Task.Run(() => View.SrcImage.Shuffle());
                View.InitDstImageZoom();
            }
            catch(Exception ex)
            {
                View.ShowError("Error while shuffling the image.");
            }
        }
    
    }
}
