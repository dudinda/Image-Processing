using System;

using ImageProcessing.Microkernel.Models.AppConfig;
using ImageProcessing.Microkernel.MVP.Code.Constants;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;

using static ImageProcessing.Microkernel.MVP.Services.Factories.StateFactory;

namespace ImageProcessing.Microkernel.MVP.Models.State.Implementation
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
                Exceptions.ApplicationIsBuilt);

        /// <inheritdoc/>
        public void Exit()
        {
            AppLifecycle.State = GetState(AppState.EndWork);
            AppLifecycle.State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
        {
            AppLifecycle.State = GetState(AppState.StartWork);
            AppLifecycle.State.Run<TMainPresenter>();
        }
    }
}
