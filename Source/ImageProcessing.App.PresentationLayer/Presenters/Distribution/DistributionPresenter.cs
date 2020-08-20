using System;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Distribution;
using ImageProcessing.App.PresentationLayer.ViewModel.Histogram;
using ImageProcessing.App.PresentationLayer.ViewModel.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Distribution
{
    internal sealed class DistributionPresenter : BasePresenter<IDistributionView, DistributionViewModel>,
        ISubscriber<TransformHistogramEventArgs>,
        ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>,
        ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        private readonly IAsyncOperationLocker _locker;
        private readonly IBitmapLuminanceServiceProvider _provider;
        
        public DistributionPresenter(
            IAppController controller,
            IAsyncOperationLocker locker,
            IBitmapLuminanceServiceProvider provider) : base(controller)
        {
            _locker = locker;
            _provider = provider;
        }

        public async Task OnEventHandler(object publisher, TransformHistogramEventArgs e)
        {
            try
            {
                var distribution = View.Dropdown;

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                copy.Tag = distribution.ToString();

                Controller.Aggregator.PublishFromAll(
                    e.Publisher,
                    new AttachBlockToRendererEventArgs(
                       block: new PipelineBlock(copy)
                           .Add<Bitmap, Bitmap>(
                               (bmp) => _provider.Transform(bmp, distribution, e.Parameters))
                           .Add<Bitmap>(
                               (bmp) => View.AddToQualityMeasureContainer(bmp))
                           .Add<Bitmap>(
                               (bmp) => View.EnableQualityQueue(true))
                    )
                );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.TransformHistogram);
            }
        }

        public async Task OnEventHandler(object publisher, ShuffleEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Aggregator.PublishFromAll(
                    e.Publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => bmp.Shuffle())
                    )
                 );                     
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.Shuffle);
            }
        }

        public async Task OnEventHandler(object publisher, BuildRandomVariableFunctionEventArgs e)
        {
            try
            {
                var copy = await _locker .LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Run<HistogramPresenter, HistogramViewModel>(
                    new HistogramViewModel(copy, e.Action));
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.BuildFunction);
            }
        }

        public async Task OnEventHandler(object publisher, ShowQualityMeasureMenuEventArgs e)
        {
            try
            {
                Controller.Run<QualityMeasurePresenter, QualityMeasureViewModel>(
                    new QualityMeasureViewModel(View.GetQualityQueue()));

                View.EnableQualityQueue(false);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.QualityHistogram);
            }
        }

        public async Task OnEventHandler(object publisher, GetRandomVariableInfoEventArgs e)
        {
            try
            {
                var container = e.Container;

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var result = await Task.Run(
                    () => _provider.GetInfo(copy, e.Action)
                ).ConfigureAwait(true);

                 View.Tooltip(result.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.RandomVariableInfo);
            }
        }

        public async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);
        }
    }
}
