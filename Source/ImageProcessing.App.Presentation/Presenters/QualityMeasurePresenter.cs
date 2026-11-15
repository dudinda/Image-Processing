using System;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Win.Services.QualityMeasure;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class QualityMeasurePresenter : BasePresenter<IQualityMeasureView, QualityMeasureViewModel>,
        ISubscriber<FormIsClosedEventArgs>
    {
        private readonly IQualityMeasureService _quality;
        private readonly ILogger<QualityMeasurePresenter> _logger;

        public QualityMeasurePresenter(
            IQualityMeasureService quality,
            ILogger<QualityMeasurePresenter> logger) 
        {
            _quality = quality;
            _logger = logger;
        }

        public override void Run(QualityMeasureViewModel vm)
            => DoWorkBeforeShow(vm);

        private async Task DoWorkBeforeShow(QualityMeasureViewModel vm)
        {
            try
            {
                var chart = View.DataChart;

                var map = await Task.Run(
                    () => _quality.BuildIntervals(vm.Queue)
                ).ConfigureAwait(true);

                foreach (var pair in map)
                {
                    chart.Series[pair.Key] = pair.Value;
                }

                View.Show();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                View.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}

