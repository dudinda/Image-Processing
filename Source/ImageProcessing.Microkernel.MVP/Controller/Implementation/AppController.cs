using ImageProcessing.Microkernel.DI.Container;
using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Implementation;
using ImageProcessing.Microkernel.MVP.IoC.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.MVP.Controller.Implementation
{
    /// <inheritdoc cref="IAppController"/>
    internal sealed class AppController : IAppController
    {
        /// <inheritdoc/>
        public IDependencyResolution IoC { get; }

        /// <inheritdoc/>
        public IEventAggregator Aggregator { get; }

        public AppController(IContainer container)
        {
            IoC = new DependencyResolution(container);

            IoC.RegisterSingletonInstance<IAppController>(this);
            
            Aggregator = IoC
                .RegisterSingleton<IEventAggregator, EventAggregator>()
                .Resolve<IEventAggregator>();
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
