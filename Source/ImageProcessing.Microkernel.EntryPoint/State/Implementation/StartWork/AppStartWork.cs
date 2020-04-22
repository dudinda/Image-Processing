using System;
using System.Threading.Tasks;

using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.DI.Code.Enums;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.Factory;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.Startup;

namespace ImageProcessing.Microkernel.State.StartWork
{
    /// <summary>
    /// An application starts its work state.
    /// </summary>
    internal sealed class AppStartWork : IAppState
    {
        /// <inheritdoc/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
            => throw new InvalidOperationException(
                "The application is already built."
            );

        /// <inheritdoc/>
        public void Exit()
        {
            AppLifecycle.State = StateFactory.Get(
                AppState.EndWork
            );

            AppLifecycle .State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => AppLifecycle
                .Controller
                .Run<TMainPresenter>();    
    }
}
