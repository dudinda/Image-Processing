using System;

using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.DI.Adapters.LightInject;
using ImageProcessing.Microkernel.DI.Adapters.Ninject;
using ImageProcessing.Microkernel.DI.Code.Enums;
using ImageProcessing.Microkernel.DI.Container;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.Factory;
using ImageProcessing.Microkernel.MVP.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.Startup;

namespace ImageProcessing.Microkernel.DI.State.IsNotBuilt
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
            try
            {
                AppLifecycle.Controller = new AppController(
                    GetContainerAdapter()
                );

                var ioc = AppLifecycle.Controller.IoC;

                if (ioc.IsRegistered<TStartup>())
                {
                    throw new InvalidOperationException(
                        "The specified startup is already defined."
                    );
                }

                ioc.RegisterSingleton<TStartup>()
                   .Resolve<TStartup>()
                   .Build(ioc);

                AppLifecycle.State = StateFactory.Get(
                    AppState.IsBuilt
                );
            }
            catch
            {
                AppLifecycle.State = StateFactory.Get(
                    AppState.EndWork
                );
                throw;
            }
      
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
