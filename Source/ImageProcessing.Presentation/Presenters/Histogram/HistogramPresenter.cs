using System;
using System.Drawing;
using System.Linq;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
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
                                  IAwaitablePipeline pipeline,
                                  IEventAggregator eventAggregator,
                                  IBitmapLuminanceDistributionService distibutionService
            ) : base(controller, view, pipeline, eventAggregator)
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

            GetFunction(out var yValues);

            View.Init(function);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series[function.GetDescription()]
                     .Points.AddXY(graylevel, yValues[graylevel]);
            }

            void GetFunction(out decimal[] values)
            {
                switch (function)
                {
                    case RandomVariable.PMF:
                        values = _distributionService.GetPMF(bitmap);
                        View.YAxisMaximum = (double)yValues.Max();
                        break;
                    case RandomVariable.CDF:
                        values = _distributionService.GetCDF(bitmap);
                        View.YAxisMaximum = 1;
                        break;

                    default: throw new NotImplementedException(nameof(function));
                }
            }
        }
    }
}
