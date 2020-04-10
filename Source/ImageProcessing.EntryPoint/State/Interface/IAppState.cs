using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Presenter;
using ImageProcessing.EntryPoint.Startup;

namespace ImageProcessing.Core.EntryPoint.State.Interface
{
    /// <summary>
    /// Represents an application state.
    /// </summary>
    internal interface IAppState
    {
        /// <summary>
        /// Build an application. Use the specified
        /// <see cref="DiContainer"/> and use <typeparamref name="TStartup"/>
        /// as an entry configuration.
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
