using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;
using ImageProcessing.EntryPoint.Startup;
using ImageProcessing.EntryPoint.State.EndWork;

namespace ImageProcessing.EntryPoint.State.StartWork
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
                "The application is already built."
            );

        /// <inheritdoc/>
        public void Exit()
        {
            AppLifecycle.State = new AppEndWork();
            AppLifecycle.State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => AppLifecycle.Controller.Run<TMainPresenter>();      
    }
}
