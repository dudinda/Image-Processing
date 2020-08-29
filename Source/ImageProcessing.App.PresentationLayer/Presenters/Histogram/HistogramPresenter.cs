using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class HistogramPresenter
        : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly IHistogramService _histogramService;

        public HistogramPresenter(
            IAppController controller,
            IHistogramService histogramService) : base(controller)
        {
            _histogramService = histogramService;
        }

        public override void Run(HistogramViewModel vm)
            => DoWorkBeforeShow(vm);

        private async Task DoWorkBeforeShow(HistogramViewModel vm)
        {
            var chart = View.DataChart;
  
            var key = vm.Mode.GetDescription();

            var info = await Task.Run(
                () => _histogramService.BuildPlot(vm.Mode, vm.Source)
            ).ConfigureAwait(true);

            chart.Series.Add(info.Plot);

            View.YAxisMaximum = (double)info.Max;
            View.Show();
        }   
    }
}
