using System.Drawing;

using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.AppController.Interface;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Services.Distribution;

namespace ImageProcessing.Presentation.Presenters
{
    public class HistogramPresenter : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly IDistributionService _distributionService;

        public HistogramPresenter(IAppController controller, 
                                  IHistogramView view, 
                                  IDistributionService distibutionService) : base(controller, view)
        {
            _distributionService = distibutionService;
        }

        public override void Run(HistogramViewModel argument)
        {
            switch(argument.Mode)
            {
                case RandomVariableAction.PMF:
                    BuildHistogram(argument.Source);
                    break;
                case RandomVariableAction.CDF:
                    BuildCDF(argument.Source);
                    break;
            }

            View.Show();
        }

        private void BuildHistogram(Bitmap bitmap)
        {
            var chart = View.GetChart;

            chart.ChartAreas[0].AxisY.MaximumAutoSize = 100;

            var frequencies = _distributionService.GetFrequencies(bitmap);
            var pmf         = _distributionService.GetPMF(frequencies, bitmap.Width * bitmap.Height);

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
            var pmf         = _distributionService.GetPMF(frequencies, bitmap.Width * bitmap.Height);
            var cdf         = _distributionService.GetCDF(pmf);

          //  Init("CDF", pmf);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series["F(x)"].Points.AddXY(graylevel, cdf[graylevel]);
            }
        }
    }
}
