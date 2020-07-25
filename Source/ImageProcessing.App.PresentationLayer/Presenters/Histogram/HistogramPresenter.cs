using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
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
        private readonly IChartSeriesBuilder _builder;

        public HistogramPresenter(IAppController controller,
                                  IBitmapLuminanceDistributionService distibutionService,
                                  IChartSeriesBuilder builder)
            : base(controller)
        {
            _distributionService = distibutionService;
            _builder = builder;
        }

        public override void Run(HistogramViewModel vm)
            => DoWorkBeforeShow(vm);

        private async Task DoWorkBeforeShow(HistogramViewModel vm)
        {
            var chart = View.GetChart;
                chart.Series.Clear();

            var key = vm.Mode.ToString();

            var (series, yMax) = await Task.Run(
                () => BuildPlot(vm)
            ).ConfigureAwait(true);

            chart.Series[key] = series;

            View.YAxisMaximum = (double)yMax;
            View.Show();
        }

        private (Series, decimal) BuildPlot(HistogramViewModel vm)
        {
            var key = vm.Mode.ToString();

            var yValues = (decimal[])_command[
                key
            ].Method.Invoke(this, new[] { vm.Source });

            var series = _builder.Build();

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
               series.Points.AddXY(graylevel, yValues[graylevel]);
            }

            return (series, yValues.Max());
        }

        [Command(nameof(RandomVariableFunction.PMF))]
        private decimal[] BuildPMFCommand(Bitmap bmp)
        {          
            _builder
               .SetName(RandomVariableFunction.PMF.GetDescription())
               .SetMarkerStyle(MarkerStyle.None)
               .SetVisibleInLegend(true);

            return _distributionService.GetPMF(bmp);
        }
       


        [Command(nameof(RandomVariableFunction.CDF))]
        private decimal[] BuildCDFCommand(Bitmap bmp)
        {
            _builder
               .SetName(RandomVariableFunction.CDF.GetDescription())
               .SetMarkerStyle(MarkerStyle.None)
               .SetChartType(SeriesChartType.StepLine)
               .SetVisibleInLegend(true);

            return _distributionService.GetCDF(bmp); 
        }
    }
}
