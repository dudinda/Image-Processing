using System.Threading.Tasks;

using ImageProcessing.Microkernel.DI.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.Startup;

namespace ImageProcessing.Microkernel.DI.EntryPoint.State.Interface
{
    /// <summary>
    /// Represents an application state.
    /// </summary>
    internal interface IAppState
    {
        /// <summary>
        /// Build an application. Use the specified
        /// <see cref="DiContainer"/> and use
        /// a <typeparamref name="TStartup"/> class
        /// as an entry configuration for dependencies.
        /// </summary>
        void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup;

        /// <summary>
        /// Run the specified <typeparamref name="TMainPresenter"/>.
        /// </summary>
        Task Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter;

        /// <summary>
        /// Exit an application.
        /// </summary>
        void Exit();
    }
}
