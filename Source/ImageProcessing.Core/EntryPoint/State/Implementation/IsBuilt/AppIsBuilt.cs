using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint.Interface;
using ImageProcessing.Core.EntryPoint.State.Implementation.Run;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.EntryPoint.State.Implementation.Exit
{
    /// <summary>
    /// Aplication has been built state.
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
            App.State = new AppEndsWork();
            App.State.Exit();
        }

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
        {
            App.State = new AppStartsWork();
            App.State.Run<TMainPresenter>();
        }
    }
}
