using System;

using ImageProcessing.Core.DI.Code.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.MVP.Presenter;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.Factory;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.EntryPoint.State.StartWork
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

            AppLifecycle.State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => AppLifecycle.Controller.Run<TMainPresenter>();      
    }
}
