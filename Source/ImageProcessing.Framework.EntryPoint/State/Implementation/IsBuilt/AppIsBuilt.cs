using System;

using ImageProcessing.Framework.Core.DI.Code.Enums;
using ImageProcessing.Framework.Core.EntryPoint.State.Interface;
using ImageProcessing.Framework.Core.MVP.Presenter;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.Factory;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.EntryPoint.State.Implementation.IsBuilt
{
    /// <summary>
    /// An application has been built state.
    /// </summary>
    internal sealed class AppIsBuilt : IAppState
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
        {
            AppLifecycle.State = StateFactory.Get(
                AppState.StartWork
            );

            AppLifecycle.State.Run<TMainPresenter>();
        }
    }
}
