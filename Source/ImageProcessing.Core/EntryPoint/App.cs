using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EntryPoint.Interface;
using ImageProcessing.Core.EntryPoint.State.Implementation;
using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.EntryPoint
{
    /// <summary>
    /// Entry point into the application lifecycle.
    /// </summary>
    public static class App
    {
        /// <inheritdoc cref="IAppController"/>
        internal static AppController Controller { get; set; }

        /// <inheritdoc cref="IAppState"/>
        internal static IAppState State { get; set; } = new AppIsNotBuilt();

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
