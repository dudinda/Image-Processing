using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;
using ImageProcessing.EntryPoint.Startup;
using ImageProcessing.EntryPoint.State.EndWork;
using ImageProcessing.EntryPoint.State.StartWork;

namespace ImageProcessing.EntryPoint.State.Implementation.IsBuilt
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
