using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal class MainSystemFake : BasePresenter<IMainView>,
          ISubscriber<AttachBlockToRendererEventArgs>,
          ISubscriber<ShowConvolutionMenuEventArgs>,
          ISubscriber<ReplaceImageEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowRgbMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {

        private readonly IEventAggregator _aggregator;

        public IMainFormExposer Publisher { get; }
        public MainPresenter Subscriber { get; }

        public MainSystemFake() : base(Substitute.For<IAppController>())
        {
            _aggregator = new EventAggregatorFake();

            Publisher = new MainForm(
                Substitute.For<IAppController>(),
                new MainFormEventBinder(_aggregator),
                Substitute.For<IMainFormCommand>());

            Subscriber = new MainPresenter(
                Substitute.For<IAppController>(),
                Substitute.For<ICacheService<Bitmap>>(),
                Substitute.For<INonBlockDialogService>(),
                Substitute.For<IAwaitablePipeline>(),
                Substitute.For<IMainPresenterLockersFacade>());

            _aggregator.Subscribe(this, Publisher);
        }

        public async virtual Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            Subscriber.OnEventHandler(publisher, e);
        }

        public async virtual Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {

        }


        public async virtual Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, ZoomEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {

        }

        public async virtual Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {

        }

    }
}
