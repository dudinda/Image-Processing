using System;
using System.Linq.Expressions;

using ImageProcessing.Core.DI.Container;

using Ninject;
using Ninject.Extensions.NamedScope;

namespace ImageProcessing.Core.DI.Adapters.Ninject
{
    /// <summary>
    /// Provides access to the Ninject <typeparamref name="StandardKernel"/>
    /// via the <see cref="IContainer"/>.
    /// </summary>
    internal sealed class NinjectAdapter : IContainer
    {
        private readonly StandardKernel _container = new StandardKernel();
    
        /// <inheritdoc/>
        public void RegisterTransient<TService, TImplementation>()
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InTransientScope();

        /// <inheritdoc/>
        public void RegisterScoped<TService, TImplementation>()
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InCallScope();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InSingletonScope();

        /// <inheritdoc/>
        public void RegisterTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InTransientScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InCallScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService
            => _container
                   .Bind<TService>()
                   .To<TImplementation>()
                   .InSingletonScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterTransient<TService>()
            => _container
                   .Bind<TService>()
                   .ToSelf()
                   .InTransientScope();

        /// <inheritdoc/>
        public void RegisterScoped<TService>()
            => _container
                   .Bind<TService>()
                   .ToSelf()
                   .InCallScope();

        /// <inheritdoc/>
        public void RegisterSingleton<TService>()
            => _container
                   .Bind<TService>()
                   .ToSelf()
                   .InSingletonScope();

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InTransientScope();

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InCallScope();

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InSingletonScope();

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance, string serviceName)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InTransientScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance, string serviceName)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InCallScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance, string serviceName)
            => _container
                   .Bind<TService>()
                   .ToConstant(instance)
                   .InSingletonScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
            => throw new NotImplementedException(nameof(factory));

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.Get<TService>();

        /// <summary>
        /// Dispose the Ninject container.
        /// </summary>
        public void Dispose()
            => _container.Dispose();

        /// <inheritdoc/>
        public void EnableAnnotatedConstructorInjection()
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public bool IsRegistered<TService>()
            => _container.CanResolve<TService>();
    }
}
