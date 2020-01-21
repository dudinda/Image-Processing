using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Helpers;
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
            Requires.IsNotNull(controller, nameof(controller));
            Requires.IsNotNull(view, nameof(view));

            _distributionService = Requires.IsNotNull(distibutionService, nameof(distibutionService));
        }

        public override void Run(HistogramViewModel vm)
        {
            Requires.IsNotNull(vm, nameof(vm));

            switch(vm.Mode)
            {
                case RandomVariable.PMF:
                    BuildPMF(vm.Source);
                    break;

                case RandomVariable.CDF:
                    BuildCDF(vm.Source);
                    break;

                default: throw new NotSupportedException();
            }

            View.Show();
        }

        private void BuildPMF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var chart = View.GetChart;

            chart.ChartAreas[0].AxisY.MaximumAutoSize = 100;

            var pmf = _distributionService.GetPMF(bitmap);

            View.Init(RandomVariable.PMF);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series[RandomVariable.PMF.GetDescription()]
                     .Points.AddXY(graylevel, pmf[graylevel]);
            }
        }

        private void BuildCDF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var chart = View.GetChart;

            chart.ChartAreas[0].AxisY.Maximum = 1;

            var cdf = _distributionService.GetCDF(bitmap);

            View.Init(RandomVariable.CDF);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series[RandomVariable.CDF.GetDescription()]
                     .Points.AddXY(graylevel, cdf[graylevel]);
            }
        }
    }
}
