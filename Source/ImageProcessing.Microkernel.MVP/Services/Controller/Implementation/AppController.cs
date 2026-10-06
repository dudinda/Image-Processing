using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.Services.Adapter;
using ImageProcessing.Microkernel.MVP.Services.Aggregator;
using ImageProcessing.Microkernel.MVP.Services.Aggregator.Implementation;
using ImageProcessing.Microkernel.MVP.Services.Providers;
using ImageProcessing.Microkernel.MVP.Services.Providers.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.Microkernel.MVP.Services.Controller.Implementation
{
    /// <inheritdoc cref="IAppController"/>
    public class AppController : IAppController
    {
        public static AppController Controller
        {
            get;
            private set => field  = value;
        }

        private AppController()
        {

        }

        /// <inheritdoc/>
        public IComponentProvider IoC { get; }

        /// <inheritdoc/>
        public IEventAggregator Aggregator { get; private set; }

        /// It is declared with the internal to restrict a client
        /// to create an instance from the application side.
        internal AppController(IContainer container)
        {
            IoC = new ComponentProvider(container);
            Aggregator = new EventAggregator();
            IoC.RegisterSingletonInstance(IoC);
            IoC.RegisterSingletonInstance(Aggregator);
            IoC.RegisterSingletonInstance<IAppController>(Controller = this);
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter}"/>
        public void Run<TPresenter>()
           where TPresenter : class, IPresenter
        {
            if(IoC.IsRegistered<ILoggerFactory>())
            {
                var factory = IoC.Resolve<ILoggerFactory>();
                IoC.RegisterTransientInstance(factory.CreateLogger<TPresenter>());
            }

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
            if (IoC.IsRegistered<ILoggerFactory>())
            {
                var factory = IoC.Resolve<ILoggerFactory>();
                IoC.RegisterTransientInstance(factory.CreateLogger<TPresenter>());
            }

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
