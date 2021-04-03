using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DIAdapter;
using ImageProcessing.Microkernel.EntryPoint.Code.Constants;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

using static ImageProcessing.Microkernel.EntryPoint.Factory.StateFactory;

namespace ImageProcessing.Microkernel.EntryPoint.State.Implementation
{
    /// <summary>
    ///An application ends its work state.
    /// </summary>
    internal sealed class AppEndWork : IAppState
    {
        /// <inheritdoc/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsBuilt);

        /// <inheritdoc/>
        public void Exit()
        {
            AppLifecycle.Controller.Dispose();
            AppLifecycle.State = GetState(AppState.IsNotBuilt);
        }
           
        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsRunning);
    }
}
