using System;

using ImageProcessing.Framework.Core.DI.Code.Enums;
using ImageProcessing.Framework.Core.EntryPoint.State.Interface;
using ImageProcessing.Framework.Core.MVP.Presenter;
using ImageProcessing.Framework.EntryPoint.Code.Enums;
using ImageProcessing.Framework.EntryPoint.Factory;
using ImageProcessing.Framework.EntryPoint.Startup;

namespace ImageProcessing.Framework.EntryPoint.State.StartWork
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
