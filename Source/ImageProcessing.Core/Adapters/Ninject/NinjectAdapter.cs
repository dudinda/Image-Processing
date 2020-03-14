using System;
using System.Linq.Expressions;

using ImageProcessing.Core.Container;

using Ninject;

namespace ImageProcessing.Core.Adapters.Ninject
{
    /// <summary>
    /// Provides access to Ninject <typeparamref name="StandardKernel"/>
    /// via <see cref="IContainer"/>.
    /// </summary>
    public sealed class NinjectAdapter : IContainer
    {
        private readonly StandardKernel _container = new StandardKernel();

        /// <inheritdoc/>
        public void EnableAnnotatedConstructorInjection()
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public bool IsRegistered<TService>()
            => _container.CanResolve<TService>();
        
        /// <inheritdoc/>
        public void Register<TService, TImplementation>()
            where TImplementation : TService
            => _container.Bind<TService>().To<TImplementation>();
        
        /// <inheritdoc/>
        public void Register<TService>()
            => _container.Bind<TService>().ToSelf();

        /// <inheritdoc/>
        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotImplementedException(nameof(factory));
        
        /// <inheritdoc/>
        public void RegisterInstance<TService>(TService instance)
            => _container.Bind<TService>().ToConstant(instance);
        
        /// <inheritdoc/>
        public void RegisterInstance<TService>(TService instance, string serviceName)
            => _container.Bind<TService>().ToConstant(instance).Named(serviceName);
        
        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService
            => _container.Bind<TService>().To<TImplementation>().InSingletonScope();
        
        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService
            => _container.Bind<TService>().To<TImplementation>().Named(serviceName);
        
        /// <inheritdoc/>
        public void RegisterSingleton<TService>()
            => _container.Bind<TService>().ToSelf().InSingletonScope();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.Get<TService>();


    }
}
