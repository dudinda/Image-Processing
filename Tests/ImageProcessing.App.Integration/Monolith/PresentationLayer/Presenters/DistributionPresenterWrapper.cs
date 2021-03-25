using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class DistributionPresenterWrapper : BasePresenter<IDistributionView, DistributionViewModel>,
        ISubscriber<TransformHistogramEventArgs>,
        ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>,
        ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        private readonly DistributionPresenter _presenter;

        public IAsyncOperationLocker Operation { get; }
        public IBitmapLuminanceServiceProvider Provider { get; }
        public IBitmapService Service { get; }

        public DistributionPresenterWrapper(
            IBitmapService service,
            IAsyncOperationLocker locker,
            IBitmapLuminanceServiceProvider provider) 
        {
            Operation = locker;
            Provider = provider;
            Service = service;

            _presenter = new DistributionPresenter(service, locker, provider);
        }

        public override void Run(DistributionViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual async Task OnEventHandler(object publisher, TransformHistogramEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, ShuffleEventArgs e)
        {
       
        }

        public virtual async Task OnEventHandler(object publisher, BuildRandomVariableFunctionEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, ShowQualityMeasureMenuEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, GetRandomVariableInfoEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            
        }
    }
}
