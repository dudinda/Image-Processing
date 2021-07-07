using System;
using System.Diagnostics;
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
            ILoggerService logger,
            IHistogramService service) 
        {
            _logger = logger;
            _service = service;
        }

        public override void Run(HistogramViewModel vm)
            => DoWorkBeforeShow(vm);

        private async Task DoWorkBeforeShow(HistogramViewModel vm)
        {
            try
            {
                var info = await Task.Run(
                    () => _service.BuildPlot(vm.Mode, vm.Source)
                ).ConfigureAwait(true);

                View.DataChart.Series.Add(info.Plot);
                View.YAxisMaximum = (double)info.Max;
                View.Show();
            }
            catch(Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }   
    }
}
