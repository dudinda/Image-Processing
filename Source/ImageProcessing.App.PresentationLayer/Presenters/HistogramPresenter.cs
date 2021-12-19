using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Services.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class HistogramPresenter
        : BasePresenter<IHistogramView, HistogramViewModel>
    {
        private readonly ILoggerService _logger;
        private readonly IHistogramService _service;

        public HistogramPresenter(
            IHistogramService service,
            ILoggerService logger) 
        {
            _logger = logger;
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
