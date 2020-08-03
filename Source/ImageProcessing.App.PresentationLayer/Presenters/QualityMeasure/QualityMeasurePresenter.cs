using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class QualityMeasurePresenter
        : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>
    {
        private readonly IQualityMeasureService _qualityService;

        public QualityMeasurePresenter(
            IAppController controller, 
            IQualityMeasureService qualityService) : base(controller) 
        {
            _qualityService = qualityService;
        }

        public override void Run(QualityMeasureViewModel vm)
            => DoWorkBeforeShow(vm);  
        
        private async Task DoWorkBeforeShow(QualityMeasureViewModel vm)
        {
            var chart = View.GetChart;
          
            var map = await Task.Run(
                () => _qualityService.BuildIntervals(vm.Queue)
            ).ConfigureAwait(true);

            foreach(var pair in map)
            {
                chart.Series[pair.Key] = pair.Value;
            }

            View.Show();
        }
    }
}

