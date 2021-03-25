using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class RgbPresenterWrapper : BasePresenter<IRgbView, RgbViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbChannelFilterEventArgs>
    {
        private readonly RgbPresenter _presenter;

        public IRgbServiceProvider Provider { get; }
        public IAsyncOperationLocker Operation { get; }

        public RgbPresenterWrapper(
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker)
        {
            Provider = provider;
            Operation = locker;

            _presenter = new RgbPresenter(provider, locker);
        }

        public override void Run(RgbViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual async Task OnEventHandler(object publisher, ApplyRgbChannelFilterEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, ApplyRgbFilterEventArgs e)
        {
           
        }
    }
}
