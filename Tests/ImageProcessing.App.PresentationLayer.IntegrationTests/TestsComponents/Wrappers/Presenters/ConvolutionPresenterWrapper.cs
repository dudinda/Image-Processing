using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.ViewModels.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class ConvolutionPresenterWrapper : BasePresenter<IConvolutionView, ConvolutionViewModel>,
          ISubscriber<ApplyConvolutionKernelEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        private readonly ConvolutionPresenter _presenter;

        public IConvolutionServiceProvider Provider { get; }
        public IAsyncOperationLocker Operation { get; }

        public ConvolutionPresenterWrapper(
            IAppController controller,
            IConvolutionServiceProvider provider,
            IAsyncOperationLocker operationLocker) : base(controller)
        {
            Provider = provider;
            Operation = operationLocker;

            _presenter = new ConvolutionPresenter(controller, provider, operationLocker);
        }

        public override void Run(ConvolutionViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual async Task OnEventHandler(object publisher, ApplyConvolutionKernelEventArgs e)
        {
          
        }

        public virtual async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
           
        }
    }
}
