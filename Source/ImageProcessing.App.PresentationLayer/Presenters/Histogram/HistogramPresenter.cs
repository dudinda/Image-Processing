using System;
using System.Drawing;
using System.Linq;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Extensions.EnumExtensions;
using ImageProcessing.App.Common.Helpers;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class HistogramPresenter
        : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        public HistogramPresenter(IAppController controller,
                                  IHistogramView view,
                                  IAwaitablePipeline pipeline,
                                  IEventAggregator eventAggregator,
                                  IBitmapLuminanceDistributionService distibutionService
            ) : base(controller, view, pipeline, eventAggregator)
        {
            _distributionService = Requires.IsNotNull(
                distibutionService, nameof(distibutionService));
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
