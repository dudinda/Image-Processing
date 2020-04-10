using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.IoC.Implementation;
using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.Controller.Implementation
{
    /// <inheritdoc cref="IAppController"/>
    internal sealed class AppController : IAppController
    {
        /// <inheritdoc cref="IDependencyResolution"/>
        public IDependencyResolution IoC { get; }

        public AppController(IContainer container)
        {
            IoC = new DependencyResolution(
                Requires.IsNotNull(container, nameof(container))
            );

            IoC.RegisterSingletonInstance<IAppController>(this);
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter}"/>
        public void Run<TPresenter>()
            where TPresenter : class, IPresenter
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.RegisterTransient<TPresenter>();
            }

            var presenter = IoC.Resolve<TPresenter>();
            presenter.Run();
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter, TViewModel}(TViewModel)"/>
        public void Run<TPresenter, TViewModel>(TViewModel vm)
            where TPresenter : class, IPresenter<TViewModel>
            where TViewModel : class
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.RegisterTransient<TPresenter>();
            }

            var presenter = IoC.Resolve<TPresenter>();

            presenter.Run(
                Requires.IsNotNull(vm, nameof(vm))
            );
        }

        /// <summary>
        /// Dispose the specified <see cref="IoC"/>.
        /// </summary>
        public void Dispose()
            => IoC.Dispose();
    }
}
