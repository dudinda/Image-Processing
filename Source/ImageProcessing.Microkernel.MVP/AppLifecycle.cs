using System;

using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Models.State;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.Services.Controller;
using ImageProcessing.Microkernel.MVP.Services.Factories;

namespace ImageProcessing.Microkernel
{
    /// <summary>
    /// The entry point into an application lifecycle.
    /// </summary>
    public class AppLifecycle : IDisposable
    {
        public AppLifecycle()
        {
            Factory = new StateFactory(this);
            State = Factory.GetState(AppState.IsNotBuilt);
        }

        /// <inheritdoc cref="IAppController"/>
        internal IAppController? Controller { get; set; }

        /// <inheritdoc cref="IAppState"/>
        internal IAppState State { get; set; }

        internal StateFactory Factory { get; }

        /// <inheritdoc cref="IAppState.Build{TStartup}(DiContainer)"/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
            => State.Build<TStartup>(container);

        /// <inheritdoc cref="IAppState.Run{TMainPresenter}"/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => State.Run<TMainPresenter>();

        /// <inheritdoc cref="IAppState.Exit"/>
        public void Exit()
            => State.Exit();

        public void Dispose()
            => Exit();
    }
}
