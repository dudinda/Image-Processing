using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.MVP.Presenter;
using ImageProcessing.Core.MVP.View;
using ImageProcessing.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;

namespace ImageProcessing.PresentationLayer.Presenters.Base
{
    /// <summary>
    /// Provides base functionality for
    /// the presentation layer of the application.
    /// Allows to access the UI layer components via a
    /// <typeparamref name="TView"/>, controls the flow of the application
    /// via the <see cref="IAppController"/> and <see cref="IAwaitablePipeline"/>
    /// and provides messaging between forms and presenters via the <see cref="IEventAggregator"/>.
    /// </summary>
    public abstract class BasePresenter<TView> : IPresenter
		where TView : class, IView
	{
        ///<inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator EventAggregator { get; }

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="IAwaitablePipeline"/>
        protected IAwaitablePipeline Pipeline { get; }

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View { get; }

        protected BasePresenter(IAppController controller,
                                TView view,
                                IAwaitablePipeline pipeline,
                                IEventAggregator eventAggregator)
        {
            EventAggregator = Requires.IsNotNull(
                eventAggregator, nameof(eventAggregator));
            Controller = Requires.IsNotNull(
                controller, nameof(controller));
            Pipeline = Requires.IsNotNull(
                pipeline, nameof(pipeline));
            View = Requires.IsNotNull(
                view, nameof(view));       
        }

        /// <inheritdoc/>
		public virtual void Run()
            => View.Show();
	}

    /// <summary>
    /// Provides base functionality for
    /// the presentation layer of the application.
    /// Allows to access the UI layer components via a
    /// <see cref="TView"/> with the specified <see cref="TViewModel"/>,
    /// controls the flow of the application
    /// via the <see cref="IAppController"/> and <see cref="IAwaitablePipeline"/>
    /// and provides messaging between forms via the <see cref="IEventAggregator"/>.
    /// </summary>
	public abstract class BasePresenter<TView, TViewModel> : IPresenter<TViewModel>
		where TView : class, IView
		where TViewModel : class
	{
        ///<inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator EventAggregator { get; }

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="IAwaitablePipeline"/>
        protected IAwaitablePipeline Pipeline { get; }

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View { get; }

        /// <summary>
        /// View model of a presenter.
        /// </summary>
        protected TViewModel ViewModel { get; private set; }

        protected BasePresenter(IAppController controller,
                                TView view,
                                IAwaitablePipeline pipeline,
                                IEventAggregator eventAggregator)
		{
            EventAggregator = Requires.IsNotNull(
                 eventAggregator, nameof(eventAggregator));
            Controller = Requires.IsNotNull(
                controller, nameof(controller));
            Pipeline = Requires.IsNotNull(
                pipeline, nameof(pipeline));
            View = Requires.IsNotNull(
                view, nameof(view));
        }

        /// <inheritdoc/>
        public virtual void Run(TViewModel vm)
		{
			ViewModel = Requires.IsNotNull(
                vm, nameof(vm));

			View.Show();
		}
	}
}
