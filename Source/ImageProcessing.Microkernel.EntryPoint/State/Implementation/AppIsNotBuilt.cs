using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.EntryPoint.Code.Constants;
using ImageProcessing.Microkernel.EntryPoint.Factory.ContainerAdapter;
using ImageProcessing.Microkernel.Factory.State;
using ImageProcessing.Microkernel.MVP.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

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
                    ContainerAdapterFactory.Get(container)
                );

                var ioc = AppLifecycle.Controller.IoC;

                if (ioc.IsRegistered<TStartup>())
                {
                    throw new InvalidOperationException(
                        Exceptions.StartupIsDefined
                    );
                }

                ioc.RegisterSingleton<TStartup>()
                   .Resolve<TStartup>().Build(ioc);

                AppLifecycle.State = StateFactory.Get(
                    AppState.IsBuilt
                );
            }
            catch(Exception ex)
            {
                AppLifecycle.State = StateFactory.Get(
                    AppState.EndWork
                );
                throw;
            }
     
        }

        /// <inheritdoc/>
        public void Exit()
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt
            );

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt
            );
        
    }
}
