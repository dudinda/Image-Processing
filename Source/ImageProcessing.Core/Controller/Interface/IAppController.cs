using System;

using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.Controller.Interface
{
    /// <summary>
    /// Represents the access point to the specified DI container,
    /// resolving dependencies via <see cref="IoC"/>.
    /// Further, controls the flow of application,
    /// by providing the <see cref="Run{TPresenter}"
    /// and <see cref="Exit{TContext}"/> methods.
    /// </summary>
    public interface IAppController
    {
        /// <summary>
        /// Provides the specified DI Container.
        /// </summary>
        IDependencyResolution IoC { get; }

        /// <summary>
        /// Run the specified <typeparamref name="TPresenter"/>.
        /// <para>Where the <typeparamref name="TPresenter"/> is a <see cref="IPresenter"/> type.</para>
        /// </summary>
        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        /// <summary>
        /// Run the specified <typeparamref name="TPresenter"/> with a selected <typeparamref name="TViewModel"/> .
        /// <para>Where the <typeparamref name="TPresenter"/> is a <see cref="IPresenter{TViewModel}"/> type.</para>
        /// </summary>
        void Run<TPresenter, TViewModel>(TViewModel vm)
            where TPresenter : class, IPresenter<TViewModel>;

        /// <summary>
        /// Exti the application by disposing
        /// the <typeparamref name="TContext"/> if
        /// it exists.
        /// </summary>
        void Exit<TContext>()
            where TContext : IDisposable;

    }
}
