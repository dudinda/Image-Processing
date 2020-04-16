using System;
using System.Drawing;
using System.Linq;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExtensions;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Microkernel.DI.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class HistogramPresenter
        : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        public HistogramPresenter(IAppController controller,
                                  IBitmapLuminanceDistributionService distibutionService)
            : base(controller)
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

        private void Build(Bitmap bitmap, RandomVariableFunction function)
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
                    case RandomVariableFunction.PMF:
                        values = _distributionService.GetPMF(bitmap);
                        View.YAxisMaximum = (double)yValues.Max();
                        break;
                    case RandomVariableFunction.CDF:
                        values = _distributionService.GetCDF(bitmap);
                        View.YAxisMaximum = 1;
                        break;

                    default: throw new NotImplementedException(nameof(function));
                }
            }
        }
    }
}
