using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.Code.Constants;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.MVP.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

using static ImageProcessing.Microkernel.EntryPoint.Factory.AdapterFactory;
using static ImageProcessing.Microkernel.EntryPoint.Factory.StateFactory;

namespace ImageProcessing.Microkernel.EntryPoint.State.Implementation
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
                AppLifecycle.Controller = new AppController(GetAdapter(container));

                var ioc = AppLifecycle.Controller.IoC;

                if (ioc.IsRegistered<TStartup>())
                {
                    throw new InvalidOperationException(
                        Exceptions.StartupIsDefined);
                }

                ioc.RegisterSingleton<TStartup>()
                   .Resolve<TStartup>().Build(ioc);

                AppLifecycle.State = GetState(AppState.IsBuilt);
            }
            catch(Exception ex)
            {
                AppLifecycle.State = GetState(AppState.EndWork);
                throw;
            }
     
        }

        /// <inheritdoc/>
        public void Exit()
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt);

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt);
    }
}
