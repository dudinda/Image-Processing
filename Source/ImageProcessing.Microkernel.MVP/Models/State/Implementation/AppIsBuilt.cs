using System;

using ImageProcessing.Microkernel.MVP.Code.Constants;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.MVP.Models.State.Implementation
{
    /// <summary>
    /// An application has been built state.
    /// </summary>
    internal sealed class AppIsBuilt : IAppState
    {
        private readonly AppLifecycle _app;

        public AppIsBuilt(AppLifecycle app)
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
            _app.State = _app.Factory.GetState(AppState.EndWork);
            _app.State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
        {
            _app.State = _app.Factory.GetState(AppState.StartWork);
            _app.State.Run<TMainPresenter>();
        }
    }
}
