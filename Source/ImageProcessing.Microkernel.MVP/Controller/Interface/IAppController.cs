using System;
using System.Threading.Tasks;

using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.Microkernel.MVP.Controller.Interface
{
    /// <summary>
    /// Represents the access point to the specified DI container,
    /// resolving dependencies via the <see cref="IoC"/>.
    /// Further, controls the flow of the application,
    /// by providing the <see cref="Run{TPresenter}"/>
    /// and <see cref="Run{TPresenter, TViewModel}"/> methods.
    /// </summary>
    public interface IAppController : IDisposable
    {
        /// <inheritdoc cref="IDependencyResolution"/>
        IDependencyResolution IoC { get; }

        /// <inheritdoc cref="IEventAggregator"/>
        IEventAggregator Aggregator { get; }

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
            where TPresenter : class, IPresenter<TViewModel>
            where TViewModel : class;
    }
}
