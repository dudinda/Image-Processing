using System;
using System.Threading.Tasks;

using ImageProcessing.Microkernel.DI.Code.Enums;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.Startup;

namespace ImageProcessing.Microkernel.State.EndWork
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
                .Controller.Dispose();

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                "The application is already running."
            );      
    }
}
