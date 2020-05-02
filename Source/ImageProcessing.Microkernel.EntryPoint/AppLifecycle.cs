using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.DI.Code.Enums;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.Factory;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.Startup;

namespace ImageProcessing.Microkernel.EntryPoint
{
    /// <summary>
    /// The entry point into an application lifecycle.
    /// </summary>
    public static class AppLifecycle
    {
        /// <inheritdoc cref="IAppController"/>
        internal static IAppController Controller { get; set; }
            = null!;

        /// <inheritdoc cref="IAppState"/>
        internal static IAppState State { get; set; }
            = StateFactory.Get(
                AppState.IsNotBuilt
            );

        /// <inheritdoc cref="IAppState.Build{TStartup}(DiContainer)"/>
        public static void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
            => State.Build<TStartup>(container);

        /// <inheritdoc cref="IAppState.Run{TMainPresenter}"/>
        public static void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => State.Run<TMainPresenter>();

        /// <inheritdoc cref="IAppState.Exit"/>
        public static void Exit()
            => State.Exit();

        /// <summary>
        /// Set a state of an application.
        /// </summary>
        internal static void SetState(AppState state)
            => State = StateFactory.Get(state);
    }
}
