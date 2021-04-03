using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.Code.Constants;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

using static ImageProcessing.Microkernel.EntryPoint.Factory.StateFactory;

namespace ImageProcessing.Microkernel.EntryPoint.State.Implementation
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
            => AppLifecycle.Controller.Run<TMainPresenter>();
    }
}
