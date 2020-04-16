using System;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Presenters.Base
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
        private Lazy<IAwaitablePipeline> _pipeline
            => new Lazy<IAwaitablePipeline>(
                Controller.IoC.Resolve<IAwaitablePipeline>
            );

        private Lazy<TView> _view
           => new Lazy<TView>(
               Controller.IoC.Resolve<TView>
           );

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="IAwaitablePipeline"/>
        protected IAwaitablePipeline Pipeline
            => _pipeline.Value;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View
            => _view.Value;
       
        protected BasePresenter(IAppController controller)
            => Controller = Requires.IsNotNull(
                controller, nameof(controller));
        
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
        private Lazy<IAwaitablePipeline> _pipeline
           => new Lazy<IAwaitablePipeline>(
               Controller.IoC.Resolve<IAwaitablePipeline>
           );

        private Lazy<TView> _view
           => new Lazy<TView>(
               Controller.IoC.Resolve<TView>
           );

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="IAwaitablePipeline"/>
        protected IAwaitablePipeline Pipeline
            => _pipeline.Value;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View
            => _view.Value;
      
        /// <summary>
        /// View model of a presenter.
        /// </summary>
        protected TViewModel ViewModel { get; private set; }

        protected BasePresenter(IAppController controller)
		    => Controller = Requires.IsNotNull(
                controller, nameof(controller));
        
        /// <inheritdoc/>
        public virtual void Run(TViewModel vm)
		{
			ViewModel = Requires.IsNotNull(
                vm, nameof(vm));

			View.Show();
		}
	}
}
