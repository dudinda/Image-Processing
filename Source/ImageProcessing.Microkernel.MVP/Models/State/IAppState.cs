using ImageProcessing.Microkernel.Models.AppConfig;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.MVP.Models.State
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
