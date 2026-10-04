using ImageProcessing.Microkernel.Models.AppConfig;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models.State;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.Services.Controller;
using ImageProcessing.Microkernel.MVP.Services.Factories;

namespace ImageProcessing.Microkernel
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
