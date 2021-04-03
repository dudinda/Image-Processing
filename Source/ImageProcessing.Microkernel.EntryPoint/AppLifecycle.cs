using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DIAdapter;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.Factory;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

namespace ImageProcessing.Microkernel.EntryPoint
{
    /// <summary>
    /// The entry point into an application lifecycle.
    /// </summary>
    public static class AppLifecycle
    {
        /// <inheritdoc cref="IAppController"/>
        internal static IAppController? Controller { get; set; }

        /// <inheritdoc cref="IAppState"/>
        internal static IAppState State { get; set; }
            = StateFactory.GetState(AppState.IsNotBuilt);

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
    }
}
