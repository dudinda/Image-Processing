using System;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.IoC.Implementation;
using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.Controller.Implementation
{
    /// <inheritdoc cref="IAppController"/>
    public class AppController : IAppController
    {
        /// <inheritdoc cref="IDependencyResolution"/>
        public IDependencyResolution IoC { get; }

        public AppController(IContainer container)
        {
            IoC = new DependencyResolution(Requires.IsNotNull(container, nameof(container)));

            IoC.RegisterInstance<IAppController>(this);
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter}"/>
        public void Run<TPresenter>()
            where TPresenter : class, IPresenter
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.Register<TPresenter>();
            }

            var presenter = IoC.Resolve<TPresenter>();
            presenter.Run();
        }

        /// <inheritdoc cref="IAppController.Run{TPresenter, TViewModel}(TViewModel)"/>
        public void Run<TPresenter, TViewModel>(TViewModel vm)
            where TPresenter : class, IPresenter<TViewModel>
        {
            if (!IoC.IsRegistered<TPresenter>())
            {
                IoC.Register<TPresenter>();
            }

            var presenter = IoC.Resolve<TPresenter>();
            presenter.Run(vm);
        }

        public void Exit<TContext>()
            where TContext : IDisposable
        {
            IoC.Resolve<TContext>().Dispose();
        }
    }
}
