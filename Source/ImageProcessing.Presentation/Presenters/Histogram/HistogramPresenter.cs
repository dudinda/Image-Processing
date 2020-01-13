using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;

namespace ImageProcessing.Presentation.Presenters
{
    public class HistogramPresenter : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        public HistogramPresenter(IAppController controller, 
                                  IHistogramView view, 
                                  IBitmapLuminanceDistributionService distibutionService) : base(controller, view)
        {
            _distributionService = distibutionService;
        }

        public override void Run(HistogramViewModel vm)
        {
            if(vm is null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            switch(vm.Mode)
            {
                case RandomVariableAction.PMF:
                    BuildHistogram(vm.Source);
                    break;
                case RandomVariableAction.CDF:
                    BuildCDF(vm.Source);
                    break;

                default: throw new NotSupportedException();
            }

            View.Show();
        }

        private void BuildHistogram(Bitmap bitmap)
        {
            var chart = View.GetChart;

            chart.ChartAreas[0].AxisY.MaximumAutoSize = 100;

            var pmf = _distributionService.GetPMF(bitmap);

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

            var cdf = _distributionService.GetCDF(bitmap);

          //  Init("CDF", pmf);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series["F(x)"].Points.AddXY(graylevel, cdf[graylevel]);
            }
        }
    }
}
