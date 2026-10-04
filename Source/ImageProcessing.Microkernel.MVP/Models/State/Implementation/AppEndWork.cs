using System;

using ImageProcessing.Microkernel.MVP.Code.Constants;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.MVP.Models.State.Implementation
{
    /// <summary>
    ///An application ends its work state.
    /// </summary>
    internal sealed class AppEndWork : IAppState
    {
        private readonly AppLifecycle _app;

        public AppEndWork(AppLifecycle app)
        {
            _app = app;
        }
        /// <inheritdoc/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsBuilt);

        /// <inheritdoc/>
        public void Exit()
        {
            _app.Controller.Dispose();
            _app.State = _app.Factory.GetState(AppState.IsNotBuilt);
        }
           
        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsRunning);
    }
}
