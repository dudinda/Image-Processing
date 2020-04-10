using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint.Interface;
using ImageProcessing.Core.EntryPoint.State.Implementation.Exit;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.EntryPoint.State.Implementation.Run
{
    /// <summary>
    /// Application starts its work state.
    /// </summary>
    internal sealed class AppStartsWork : IAppState
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
            App.State = new AppEndsWork();
            App.Controller.Dispose();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => App.Controller.Run<TMainPresenter>();      
    }
}
