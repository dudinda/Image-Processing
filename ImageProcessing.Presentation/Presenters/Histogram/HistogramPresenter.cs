using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.AppController;
using ImageProcessing.DomainModel.Services.Distribution;

using System.Drawing;

namespace ImageProcessing.Presentation.Presenters
{
    public class HistogramPresenter : BasePresenter<IHistogramView, Bitmap>
    {
        private readonly IDistributionService _distributionService;

        private Bitmap _src;

        public HistogramPresenter(IAppController controller, 
                                  IHistogramView view, 
                                  IDistributionService distibutionService) : base(controller, view)
        {
            _distributionService = distibutionService;
        }

        public override void Run(Bitmap argument)
        {
            _src = argument;
            View.Show();
        }

        private void BuildHistogram(Bitmap bitmap)
        {
            var chart = View.GetChart;
            chart.ChartAreas[0].AxisY.MaximumAutoSize = 100;
            var frequencies = _distributionService.GetFrequencies(bitmap);
            var pmf = _distributionService.GetPMF(frequencies, bitmap.Width * bitmap.Height);

            //Init("PMF", pmf);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series["p(x)"].Points.AddXY(graylevel, pmf[graylevel]);
            }
        }

        private void BuildCDF(Bitmap bitmap)
        {
            var chart = View.GetChart;
            chart.ChartAreas[0].AxisY.Maximum = 1;
            var frequencies = _distributionService.GetFrequencies(bitmap);
            var pmf = _distributionService.GetPMF(frequencies, bitmap.Width * bitmap.Height);
            var cdf = _distributionService.GetCDF(pmf);

          //  Init("CDF", pmf);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series["F(x)"].Points.AddXY(graylevel, cdf[graylevel]);
            }
        }
    }
}
