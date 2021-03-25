using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class QualityMeasurePresenter
        : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IQualityMeasureService _quality;

        public QualityMeasurePresenter(
            IQualityMeasureService quality) 
        {
            _quality = quality;
        }

        public override void Run(QualityMeasureViewModel vm)
            => DoWorkBeforeShow(vm);  
        
        private async Task DoWorkBeforeShow(QualityMeasureViewModel vm)
        {
            var chart = View.DataChart;
          
            var map = await Task.Run(
                () => _quality.BuildIntervals(vm.Queue)
            ).ConfigureAwait(true);

            foreach(var pair in map)
            {
                chart.Series[pair.Key] = pair.Value;
            }

            View.Show();
        }
    }
}

