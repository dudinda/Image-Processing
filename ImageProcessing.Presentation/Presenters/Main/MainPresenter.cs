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

using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;

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
                             IConvolutionFilterService convolutionFilterService,
                             IDistributionService distributionService,
                             IRGBFilterService rgbFilterService,
                             IBaseFactory baseFactory) : base(controller, view)
        {
            _convolutionFilterService = convolutionFilterService;
            _distributionService      = distributionService;
            _rgbFilterService         = rgbFilterService;

            _convolutionFilterFactory = baseFactory.GetConvolutionFilterFactory();
            _distributionFactory      = baseFactory.GetDistributionFactory();
            _rgbFiltersFactory        = baseFactory.GetRGBFilterFactory();

            View.ApplyConvolutionFilter       += (filter) => ApplyConvolutionFilter(filter);
            View.ApplyRGBFilter               += (filter) => ApplyRGBFilter(filter);
            View.ApplyHistogramTransformation += (distribution, parms) => ApplyHistogramTransformation(distribution, parms);
            View.SaveImage += () => SaveImage();
            View.OpenImage += () => OpenImage(View.Path);
            View.Shuffle   += () => Shuffle();

        }

        private async void OpenImage(string fileName)
        {
            var openFileDialog = new OpenFileDialog()
            {

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "BMP Files (*.bmp)|*.bmp|"    +
                         "JPEG Files (*.jpeg)|*.jpeg|" +
                         "PNG Files (*.png)|*.png|"    +
                         "JPG Files (*.jpg)|*.jpg|"    +
                         "GIF Files (*.gif)|*.gif|"    +
                         "All Files (*.*)|*.*"
            };

            Bitmap openResult = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openResult = await Task.Run(() => {

                    using (var stream = File.OpenRead(openFileDialog.FileName))
                    {
                        return new Bitmap(Image.FromStream(stream));
                    }

                });

                View.Path = openFileDialog.FileName;
            }

            View.InitSrcImageZoom();
            View.SrcImage = openResult;
        }


        private async void SaveImage()
        {
            var saveFileDialog = new SaveFileDialog()
            {

                Filter = "BMP Files (*.bmp)|*.bmp|"    +
                         "JPEG Files (*.jpeg)|*.jpeg|" +
                         "PNG Files (*.png)|*.png|"    +
                         "JPG Files (*.jpg)|*.jpg|"    +
                         "GIF Files (*.gif)|*.gif|"    +
                         "All Files (*.*)|*.*"
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


        private async void ApplyConvolutionFilter(string filterName)
        {
            if (View.SrcIsNull) return;

            var filter = _convolutionFilterFactory.GetFilter(filterName);

            View.DstImage = await Task.Run(() => _convolutionFilterService.Convolution(View.SrcImage, filter));
            View.InitDstImageZoom();
        }


        private async void ApplyRGBFilter(string filterName)
        {
            if (View.SrcIsNull) return;

            var filter = _rgbFiltersFactory.GetFilter(filterName);

            View.DstImage = await Task.Run(() => _rgbFilterService.Filter(View.SrcImage, filter));
            View.InitDstImageZoom();
        }


        private async void ApplyHistogramTransformation(string filterName, (double, double) parms)
        {
            if (View.SrcIsNull) return;

            var filter = _distributionFactory.GetFilter(filterName);
                filter.SetParams(parms);

            View.DstImage = await Task.Run(() => _distributionService.Distribute(View.SrcImage, filter));
            View.InitDstImageZoom();
        }

        private async void Shuffle()
        {
            if (View.SrcIsNull) return;

            View.DstImage = await Task.Run(() => View.SrcImage.Shuffle());
            View.InitDstImageZoom();
        }

    }
}
