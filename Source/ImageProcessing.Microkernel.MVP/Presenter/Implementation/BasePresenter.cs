using System;

using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Presenters.Base
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
        private TView? _view;
        private IAppController? _controller;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => _controller ??= AppController.Controller;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View
        {
            get
            {
                if(_view is null)
                {
                    _view = Controller.IoC.Resolve<TView>();

                    Controller
                        .Aggregator
                        .Subscribe(this, _view);
                }

                return _view;
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
        private TView? _view;
        private TViewModel? _vm;
        private IAppController? _controller;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => _controller ??= AppController.Controller;

        /// <summary>
        /// Access point to the UI layer components.
        /// </summary>
        protected TView View
        {
            get
            {
                if (_view is null)
                {
                    _view = Controller
                        .IoC.Resolve<TView>();

                    Controller
                        .Aggregator
                        .Subscribe(this, _view);
                }

                return _view;
            }
        }

        /// <summary>
        /// View model of a presenter.
        /// </summary>
        protected TViewModel ViewModel
        {
            get => _vm ?? throw new ArgumentNullException(nameof(_vm));
            private set => _vm = value;        
        }

        /// <inheritdoc/>
        public virtual void Run(TViewModel vm)
		{
            ViewModel = vm;
            View.Show();
		}
	}
}
