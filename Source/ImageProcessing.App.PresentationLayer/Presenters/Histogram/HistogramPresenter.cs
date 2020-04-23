using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class HistogramPresenter
        : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private static readonly Dictionary<string, CommandAttribute>
           _command = typeof(HistogramPresenter).GetCommands();

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

            var yValues = (decimal[])_command[
                function.ToString()
            ].Method.Invoke(this, new[] { bitmap });

            View.Init(function);

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                chart.Series[function.GetDescription()]
                     .Points.AddXY(graylevel, yValues[graylevel]);
            }
        }

        [Command(nameof(RandomVariableFunction.PMF))]
        private decimal[] BuildPMFCommand(Bitmap bmp)
        {
            var values = _distributionService.GetPMF(bmp);
            View.YAxisMaximum = (double)values.Max();

            return values;
        }

        [Command(nameof(RandomVariableFunction.CDF))]
        private decimal[] BuildCDFCommand(Bitmap bmp)
        {
            View.YAxisMaximum = 1;

            return _distributionService.GetCDF(bmp);
        }
    }
}
