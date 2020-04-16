using System;

using ImageProcessing.Microkernel.DI.Aggregator.Implementation;
using ImageProcessing.Microkernel.DI.Aggregator.Interface.Aggregator;
using ImageProcessing.Microkernel.DI.Container;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.Microkernel.DI.IoC.Implementation;
using ImageProcessing.Microkernel.DI.IoC.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.DI.Controller.Implementation
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