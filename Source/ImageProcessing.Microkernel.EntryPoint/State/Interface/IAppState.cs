using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DIAdapter;
using ImageProcessing.Microkernel.MVP.Presenter.Interface;

namespace ImageProcessing.Microkernel.DI.EntryPoint.State.Interface
{
    /// <summary>
    /// Represents a state of the application.
    /// </summary>
    internal interface IAppState
    {
        /// <summary>
        /// Build an application. Use the specified
        /// <see cref="DiContainer"/> and use
        /// a <typeparamref name="TStartup"/> class
        /// as the initial configuration for components.
        /// </summary>
        void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup;

        /// <summary>
        /// Run the specified <typeparamref name="TMainPresenter"/>.
        /// </summary>
        void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter;

        /// <summary>
        /// Exit an application.
        /// </summary>
        void Exit();
    }
}
