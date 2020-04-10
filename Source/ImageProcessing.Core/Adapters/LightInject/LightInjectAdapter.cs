using System;
using System.Linq.Expressions;

using ImageProcessing.Core.Container;

using LightInject;

namespace ImageProcessing.Core.Adapters.LightInject
{
    /// <summary>
    /// Provides access to the LightInject <typeparamref name="ServiceContainer"/>
    /// via the <see cref="IContainer"/>.
    /// </summary>
    internal sealed class LightInjectAdapter : IContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        /// <inheritdoc/>
        public void RegisterTransient<TService, TImplementation>()
            where TImplementation : TService
            => _container.Register<TService, TImplementation>();

        /// <inheritdoc/>
        public void RegisterScoped<TService, TImplementation>()
            where TImplementation : TService
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService, TImplementation>(string name)
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(name);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TImplementation>(string name)
            where TImplementation : TService
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>(string name)
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(name, new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService>()
            => _container.Register<TService>();

        /// <inheritdoc/>
        public void RegisterScoped<TService>()
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService>()
            => _container.Register<TService>(new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance)
            => _container.RegisterInstance(instance);

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance)
             => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance, string serviceName)
            => _container.RegisterInstance(instance, serviceName: serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance, string serviceName)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance, string serviceName)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => _container.Register(serviceFactory => factory);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => _container.Register(serviceFactory => factory, new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string serviceName)
            => _container.Register(serviceFactory => factory, serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string serviceName)
            => throw new NotSupportedException();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string serviceName)
            => _container.Register(serviceFactory => factory, serviceName, new PerContainerLifetime());

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.GetInstance<TService>();

        /// <inheritdoc/>
        public void EnableAnnotatedConstructorInjection()
            => _container.EnableAnnotatedConstructorInjection();

        /// <inheritdoc/>
        public bool IsRegistered<TService>()
            => _container.CanGetInstance(typeof(TService), string.Empty);

        /// <summary>
        /// Dispose the LightInject container.
        /// </summary>
        public void Dispose()
            => _container.Dispose();
        
    }
}


