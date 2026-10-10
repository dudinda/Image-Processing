using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class MainTrackbarPresenterWrapper : BasePresenter<IMainView>, ISubscriber<TrackBarEventArgs>
    {
        public override IMainView View
          => field ??= Controller.IoC.Resolve<IMainView>();

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        public ILoggerFactory Factory { get; }
        public IBitmapCopyServiceWrapper Reference { get; }
        public IAwaitablePipelineServiceWrapper Pipeline { get; }
        public IScalingProviderWrapper Scaling { get; }
        public IRotationProviderWrapper Rotation { get; }

        public MainTrackbarPresenterWrapper(
            ILoggerFactory factory,
            IBitmapCopyServiceWrapper reference,
            IAwaitablePipelineServiceWrapper pipeline,
            IScalingProviderWrapper scaling,
            IRotationProviderWrapper rotation)
        {
            Factory = factory;
            Reference = reference;
            Pipeline = pipeline;
            Scaling = scaling;
            Rotation = rotation;
        }

        public Task OnEventHandler(object publisher, TrackBarEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
