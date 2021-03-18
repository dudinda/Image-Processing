using System;

using ImageProcessing.Microkernel.DIAdapter.Container;
using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Implementation;
using ImageProcessing.Microkernel.MVP.IoC.Interface;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

namespace ImageProcessing.Microkernel.MVP.Controller.Implementation
{
    /// <inheritdoc cref="IAppController"/>
    public class AppController : IAppController
    {
        private static AppController? _controller;

        public static AppController Controller
        {
            get => _controller ?? throw new ArgumentNullException(nameof(_controller));
            private set => _controller = value;
        }

        private AppController()
        {

        }

        /// <inheritdoc/>
        public IDependencyResolution IoC { get; }

        /// <inheritdoc/>
        public IEventAggregator Aggregator { get; private set; }

        /// It is declared with the internal to restrict a client
        /// to create an instance from the application side.
        internal AppController(IContainer container)
        {
            IoC = new DependencyResolution(container);
            IoC.RegisterSingletonInstance<IAppController>(Controller = this);
            IoC.RegisterSingleton<IEventAggregator, EventAggregator>();
            Aggregator = IoC.Resolve<IEventAggregator>();
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter}"/>
        public void Run<TPresenter>()
           where TPresenter : class, IPresenter
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.RegisterTransient<TPresenter>();
            }

            IoC.Resolve<TPresenter>().Run();
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter, TViewModel}(TViewModel)"/>
        public void Run<TPresenter, TViewModel>(TViewModel vm)
            where TPresenter : class, IPresenter<TViewModel>
            where TViewModel : class
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.RegisterTransient<TPresenter>();
            }

            IoC.Resolve<TPresenter>().Run(vm);
        }

        /// <summary>
        /// Dispose the specified <see cref="IoC"/>.
        /// </summary>
        public void Dispose()
            => IoC.Dispose();   
    }
}
