using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class DistributionPresenterWrapper : BasePresenter<IDistributionView, BitmapViewModel>,
        ISubscriber<TransformHistogramEventArgs>,
        ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>,
        ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>
    {
        private readonly DistributionPresenter _presenter;

        public IAsyncOperationLocker Operation { get; }
        public IBitmapLuminanceProvider Provider { get; }
        public IBitmapService Service { get; }
        public ILoggerService Logger { get; }

        public DistributionPresenterWrapper(
            IBitmapLuminanceProvider provider,
            IAsyncOperationLockerWrapper locker,
            IBitmapServiceWrapper service,
            ILoggerServiceWrapper logger) 
        {
            Operation = locker;
            Provider = provider;
            Service = service;
            Logger = logger;

            _presenter = new DistributionPresenter(provider, locker, service, logger);
        }

        public override void Run(BitmapViewModel vm)
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

        public virtual async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            
        }
    }
}
