using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class QualityMeasurePresenter
        : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;
        private readonly IChartSeriesBuilder _builder;

        public QualityMeasurePresenter(IAppController controller, 
                                       IBitmapLuminanceDistributionService distibutionService,
                                       IChartSeriesBuilder builder)
            : base(controller) 
        {
            _distributionService = Requires.IsNotNull(
                distibutionService, nameof(distibutionService));
            _builder = Requires.IsNotNull(
                builder, nameof(builder));
        }

        public override async Task Run(QualityMeasureViewModel vm)
        {
            Requires.IsNotNull(vm, nameof(vm));

            BuildHistogram(vm);

            View.Show();
        }

        private void BuildHistogram(QualityMeasureViewModel vm)
        {
            var chart = View.GetChart;
                chart.Series.Clear();

            var random = new Random(Guid.NewGuid().GetHashCode());

            while(vm.Queue.TryDequeue(out var bitmap))
            {
                var variance = new List<decimal>();
                var names    = new List<string>();

                for (var graylevel = 0; graylevel < 255; graylevel += 15)
                {
                    names.Add($"{graylevel}-{graylevel + 15}");
                    variance.Add(_distributionService.GetConditionalVariance((graylevel, graylevel + 15), bitmap));
                }

                var key = bitmap.Tag.ToString();

                _builder.SetName(key)
                        .SetColor(Color.FromArgb(random.Next(0, 256),
                                                 random.Next(0, 256),
                                                 random.Next(0, 256))
                        )
                        .SetMarkerStyle(MarkerStyle.None)
                        .SetChartType(SeriesChartType.Column)
                        .SetLabelAngle(-90);


                chart.Series.Add(_builder.Build());
                chart.Series[key].Points.DataBindXY(names, variance);
            }
        }
    }
}

