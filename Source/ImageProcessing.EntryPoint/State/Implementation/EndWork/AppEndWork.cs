using System;

using ImageProcessing.Core.DI.Code.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.MVP.Presenter;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.EntryPoint.State.EndWork
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
                "The application is already built."
            );

        /// <inheritdoc/>
        public void Exit()
            => AppLifecycle
                .Controller
                .Dispose();

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                "The application is already running."
            );      
    }
}
