using System;

using ImageProcessing.Core.DI.Adapters.LightInject;
using ImageProcessing.Core.DI.Adapters.Ninject;
using ImageProcessing.Core.DI.Container;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.DI.Code.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.MVP.Presenter;
using ImageProcessing.EntryPoint;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.Factory;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.Core.EntryPoint.State.IsNotBuilt
{
    /// <summary>
    /// An application has not been built state.
    /// </summary>
    internal sealed class AppIsNotBuilt : IAppState
    {
        /// <inheritdoc/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
        {
            AppLifecycle.Controller = new AppController(GetContainerAdapter());

            if (AppLifecycle.Controller.IoC.IsRegistered<TStartup>())
            {
                throw new InvalidOperationException(
                    "The specified startup is already defined."
                );
            }

            AppLifecycle.Controller.IoC.RegisterSingleton<TStartup>();

            AppLifecycle.Controller.IoC
                .Resolve<TStartup>()
                .Build(AppLifecycle.Controller.IoC);

            AppLifecycle.State = StateFactory.Get(
                AppState.IsBuilt
            );

            IContainer GetContainerAdapter()
                => container
            switch
            {
                DiContainer.LightInject
                    => new LightInjectAdapter(),
                DiContainer.Ninject
                    => new NinjectAdapter(),

                _ => throw new NotImplementedException(nameof(container))
            };
        }

        /// <inheritdoc/>
        public void Exit()
            => throw new InvalidOperationException(
                "The application is not built."
            );

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                "The application is not built."
            );
        
    }
}
