using System.Collections.Generic;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class QualityMeasurePresenter
        : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        public QualityMeasurePresenter(IAppController controller, 
                                       IBitmapLuminanceDistributionService distibutionService)
            : base(controller) 
        {
            _distributionService = Requires.IsNotNull(
                distibutionService, nameof(distibutionService));
        }

        public override void Run(QualityMeasureViewModel vm)
        {
            Requires.IsNotNull(vm, nameof(vm));

            BuildHistogram(vm);

            View.Show();
        }

        private void BuildHistogram(QualityMeasureViewModel vm)
        {
            var chart = View.GetChart;

            while(vm.Queue.TryDequeue(out var bitmap))
            {
                var variance = new List<decimal>();
                var names = new List<string>();

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

