using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.Factory;
using ImageProcessing.EntryPoint.Startup;
using ImageProcessing.EntryPoint.State.StartWork;

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
