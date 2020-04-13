using System;

using ImageProcessing.Framework.Core.DI.Code.Enums;
using ImageProcessing.Framework.Core.EntryPoint.State.Interface;
using ImageProcessing.Framework.Core.MVP.Presenter;
using ImageProcessing.Framework.EntryPoint.Code.Enums;
using ImageProcessing.Framework.EntryPoint.Factory;
using ImageProcessing.Framework.EntryPoint.Startup;

namespace ImageProcessing.Framework.EntryPoint.State.Implementation.IsBuilt
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
