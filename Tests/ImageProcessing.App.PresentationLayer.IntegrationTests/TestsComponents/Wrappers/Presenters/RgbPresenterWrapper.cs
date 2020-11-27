using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Rgb;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

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
            IAppController controller,
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker) : base(controller)
        {
            Provider = provider;
            Operation = locker;

            _presenter = new RgbPresenter(controller, provider, locker);
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
