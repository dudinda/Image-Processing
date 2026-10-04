using System;

using ImageProcessing.Microkernel.MVP.Services.Aggregator;
using ImageProcessing.Microkernel.MVP.Services.Controller;
using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.Microkernel.MVP.Presenter.Implementation
{
    /// <summary>
    /// Provides base functionality for
    /// the presentation layer of the application.
    /// Allows to access the UI layer components via a
    /// <typeparamref name="TView"/>, controls the flow of the application
    /// via the <see cref="IAppController"/> and provides messaging between forms
    /// and presenters via the <see cref="IEventAggregator"/>.
    /// </summary>
    public abstract class BasePresenter<TView> : IPresenter
		where TView : class, IView
	{

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => field ??= AppController.Controller;

        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator Aggregator
            => Controller.Aggregator;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        public virtual TView View
        {
            get
            {
                if(field is null)
                {
                    field = Controller.IoC.Resolve<TView>();

                    Controller
                        .Aggregator
                        .Subscribe(this, field);
                }

                return field;
            }
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
    /// via the <see cref="IAppController"/> and provides messaging between forms
    /// and presenters via the <see cref="IEventAggregator"/>.
    /// </summary>
    public abstract class BasePresenter<TView, TViewModel> : IPresenter<TViewModel>
		where TView : class, IView
		where TViewModel : class
	{

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => field ??= AppController.Controller;

        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator Aggregator
            => Controller.Aggregator;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        public virtual TView View
        {
            get
            {
                if (field is null)
                {
                    field = Controller.IoC.Resolve<TView>();

                    Controller
                        .Aggregator
                        .Subscribe(this, field);
                }

                return field;
            }
        }

        /// <summary>
        /// View model of a presenter.
        /// </summary>
        protected TViewModel ViewModel
        {
            get => field ?? throw new ArgumentNullException(nameof(ViewModel));
            private set => field = value;        
        }

        /// <inheritdoc/>
        public virtual void Run(TViewModel vm)
		{
            ViewModel = vm;
            View.Show();
		}
	}
}
