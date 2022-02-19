using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters
{
    internal class MainMenuPresenterWrapper : BasePresenter<IMainView>,
        ISubscriber<ShowConvolutionMenuEventArgs>, ISubscriber<ShowDistributionMenuEventArgs>,
        ISubscriber<ShowRgbMenuEventArgs>, ISubscriber<ShowSettingsMenuEventArgs>,
        ISubscriber<ShowTransformationMenuEventArgs>, ISubscriber<ShowRotationMenuEventArgs>,
        ISubscriber<ShowScalingMenuEventArgs>
    {
        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
