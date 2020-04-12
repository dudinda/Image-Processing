using System.Collections.Generic;
using System.Drawing;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.Framework.Core.Controller.Interface;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class QualityMeasurePresenter
        : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        public QualityMeasurePresenter(IAppController controller, 
                                       IQualityMeasureView view,
                                       IAwaitablePipeline pipeline,
                                       IEventAggregator eventAggregator,
                                       IBitmapLuminanceDistributionService distibutionService
            ) : base(controller, view, pipeline, eventAggregator) 
        {
            _distributionService = Requires.IsNotNull(
                distibutionService, nameof(distibutionService));
        }

        public void BuildHistogram()
        {
            var chart = View.GetChart;
            var list = new List<Bitmap>();

            for (var step = 0; step < list.Count; ++step)
            {
                var bitmap = list[step];

                var variance = new List<decimal>();
                var names    = new List<string>();

                for (int graylevel = 0; graylevel < 255; graylevel += 15)
                {
                    names.Add($"{graylevel}-{graylevel + 15}");
                    variance.Add(_distributionService.GetConditionalVariance((graylevel, graylevel + 15), bitmap));
                }

                chart.Series[bitmap.Tag.ToString()].Points.DataBindXY(names, variance);
                chart.Series[bitmap.Tag.ToString()].LabelAngle = -90;
            }
        }
    }
}

