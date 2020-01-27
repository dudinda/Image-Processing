using System;

using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Presenter;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Controller.Implementation
{
    public class AppController : IAppController
    {
        private readonly IContainer _container;

        public AppController(IContainer container)
        {
            if(container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            _container = container;
            _container.RegisterInstance<IAppController>(this);
        }

        public IAppController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IAppController RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IAppController RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        public IAppController RegisterSingletonService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.RegisterSingleton<TModel, TImplementation>();
            return this;
        }

        public IAppController EnableAnnotatedConstructorInjection()
        {
            _container.EnableAnnotatedConstructorInjection();
            return this;
        }

        public IAppController RegisterNamedSingletonService<TModel, TImplementation>(string name)
           where TImplementation : class, TModel
        {
            _container.RegisterSingleton<TModel, TImplementation>(name);
            return this;
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
            {
                _container.Register<TPresenter>();
            }

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : class, IPresenter<TArgumnent>
        {
            if (!_container.IsRegistered<TPresenter>())
            {
                _container.Register<TPresenter>();
            }

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(argumnent);
        }
    }
}
