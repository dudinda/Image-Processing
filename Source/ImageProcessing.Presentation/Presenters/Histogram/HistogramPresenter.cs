using System;
using System.Drawing;
using System.Linq;

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
            _distributionService = Requires.IsNotNull(distibutionService, nameof(distibutionService));
        }

        public override void Run(HistogramViewModel vm)
        {
            Requires.IsNotNull(vm, nameof(vm));

            Build(vm.Source, vm.Mode);

            View.Show();
        }

        private void Build(Bitmap bitmap, RandomVariable function)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            var chart = View.GetChart;

            decimal[] yValues;

            switch(function)
            {
                case RandomVariable.PMF:
                    yValues = _distributionService.GetPMF(bitmap);
                    View.YAxisMaximum = (double)yValues.Max();
                    break;
                case RandomVariable.CDF:
                    yValues = _distributionService.GetCDF(bitmap);
                    View.YAxisMaximum = 1;
                    break;

                default: throw new InvalidOperationException(nameof(function));
            }
           
            View.Init(function);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series[function.GetDescription()]
                     .Points.AddXY(graylevel, yValues[graylevel]);
            }
        }
    }
}
