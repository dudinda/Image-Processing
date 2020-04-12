using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.DI.Code.Enums;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.MVP.Presenter;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.Factory;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.EntryPoint
{
    /// <summary>
    /// Entry point into the application lifecycle.
    /// </summary>
    public static class AppLifecycle
    {
        /// <inheritdoc cref="IAppController"/>
        internal static IAppController Controller { get; set; }

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
        public static void SetState(AppState state)
            => State = StateFactory.Get(state);
    }
}
