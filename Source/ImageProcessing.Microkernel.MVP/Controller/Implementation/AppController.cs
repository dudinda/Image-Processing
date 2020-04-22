using System;
using System.Threading.Tasks;

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
        public async Task Run<TPresenter>()
            where TPresenter : class, IPresenter
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.RegisterTransient<TPresenter>();
            }

            await IoC
                .Resolve<TPresenter>()
                .Run()
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter, TViewModel}(TViewModel)"/>
        public async Task Run<TPresenter, TViewModel>(TViewModel vm)
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

            await IoC
                .Resolve<TPresenter>()
                .Run(vm)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Dispose the specified <see cref="IoC"/>.
        /// </summary>
        public void Dispose()
            => IoC.Dispose();
    }
}
