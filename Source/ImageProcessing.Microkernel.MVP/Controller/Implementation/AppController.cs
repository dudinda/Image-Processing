using System;

using ImageProcessing.Microkernel.DI.Container;
using ImageProcessing.Microkernel.MVP.Presenter;

using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface.Aggregator;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Implementation;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

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
            if(container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            IoC = new DependencyResolution(container);

            IoC.RegisterSingletonInstance<IAppController>(this);
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
            if(vm is null)
            {
                throw new ArgumentNullException(nameof(vm));
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
