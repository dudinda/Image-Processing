using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.Core.Presenter;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Controller.Interface
{
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

    }
}
