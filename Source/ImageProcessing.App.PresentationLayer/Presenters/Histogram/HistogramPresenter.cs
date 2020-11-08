using System.Threading.Tasks;

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
        private readonly IHistogramService _service;

        public HistogramPresenter(
            IAppController controller,
            IHistogramService service) : base(controller)
        {
            _service = service;
        }

        public override void Run(HistogramViewModel vm)
            => DoWorkBeforeShow(vm);

        private async Task DoWorkBeforeShow(HistogramViewModel vm)
        {
            var info = await Task.Run(
                () => _service.BuildPlot(vm.Mode, vm.Source)
            ).ConfigureAwait(true);

            View.DataChart.Series.Add(info.Plot);
            View.YAxisMaximum = (double)info.Max;
            View.Show();
        }   
    }
}
