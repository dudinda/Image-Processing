using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Distribution;
using ImageProcessing.App.PresentationLayer.ViewModel.Distribution;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

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

        public DistributionPresenterWrapper(
            IAppController controller,
            IAsyncOperationLocker locker,
            IBitmapLuminanceServiceProvider provider) : base(controller)
        {
            Operation = locker;
            Provider = provider;

            _presenter = new DistributionPresenter(controller, locker, provider);
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
