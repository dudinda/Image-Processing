using System.Drawing;
using System.Collections.Generic;

using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Core.Presenter.Abstract;
using ImageProcessing.Core.AppController.Interface;
using ImageProcessing.Services.Distribution;


namespace ImageProcessing.Presentation.Presenters
{
    public class QualityMeasurePresenter : BasePresenter<IQualityMeasureView, Bitmap>
    {
        private readonly IDistributionService _distributionService;

        private Bitmap _src;

        public QualityMeasurePresenter(IAppController controller, 
                                       IQualityMeasureView view, 
                                       IDistributionService distibutionService) : base(controller, view)
        {
            _distributionService = distibutionService;
        }

        public override void Run(Bitmap argument)
        {
            _src = argument;
            View.Show();
        }

        public void BuildHistogram()
        {
            var chart = View.GetChart;
            var list = new List<Bitmap>();

            for (var step = 0; step < list.Count; ++step)
            {
                var bitmap = list[step];

                var frequencies = _distributionService.GetFrequencies(bitmap);

                var pmf = _distributionService.GetPMF(frequencies, bitmap.Width * bitmap.Height);

                var variance = new List<double>();
                var names    = new List<string>();

                for (int graylevel = 0; graylevel < 255; graylevel += 15)
                {
                    names.Add($"{graylevel}-{graylevel + 15}");
                    variance.Add(_distributionService.GetConditionalVariance(graylevel, graylevel + 15, pmf));
                }

                chart.Series[bitmap.Tag.ToString()].Points.DataBindXY(names, variance);
                chart.Series[bitmap.Tag.ToString()].LabelAngle = -90;
            }
        }
    }
}

