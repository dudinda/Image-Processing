using System.Collections.Generic;
using System.Drawing;

using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Presentation.ViewModel.QualityMeasure;
using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;

namespace ImageProcessing.Presentation.Presenters
{
    public class QualityMeasurePresenter : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IBitmapLuminanceDistributionService _distributionService;

        private Bitmap _src;

        public QualityMeasurePresenter(IAppController controller, 
                                       IQualityMeasureView view, 
                                       IBitmapLuminanceDistributionService distibutionService) : base(controller, view)
        {
            _distributionService = distibutionService;
        }

        public override void Run(QualityMeasureViewModel vm)
        {
            _src = vm.Bitmap;

            View.Show();
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

