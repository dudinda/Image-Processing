using System;

using LightInject;

namespace ImageProcessing.Microkernel.MVP.Services.Adapter.Implementation
{
    /// <summary>
    /// Provides access to the LightInject <see cref="ServiceContainer"/>
    /// via the <see cref="IContainer"/>.
    /// </summary>
    internal sealed class LightInjectAdapter : IContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        /// <inheritdoc/>
        public void RegisterTransient<TService, TImplementation>()
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(new PerRequestLifeTime());

        /// <inheritdoc/>
        public void RegisterScoped<TService, TImplementation>()
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(new PerScopeLifetime());

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
            => _container.Register<TService, TImplementation>(name, new PerScopeLifetime());

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TImplementation>(string name)
            where TImplementation : TService
            => _container.Register<TService, TImplementation>(name, new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService>()
            => _container.Register<TService>();

        /// <inheritdoc/>
        public void RegisterScoped<TService>()
            => _container.Register<TService>(new PerScopeLifetime());

        /// <inheritdoc/>
        public void RegisterSingleton<TService>()
            => _container.Register<TService>(new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance)
            => _container.Register<TService>(factory => instance, new PerRequestLifeTime());

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance)
            => _container.Register<TService>(factory => instance, new PerScopeLifetime());

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance)
            => _container.RegisterInstance(typeof(TService), instance);

        /// <inheritdoc/>
        public void RegisterTransient<TService>(TService instance, string serviceName)
            => _container.Register<TService>(factory => instance, serviceName: serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService>(TService instance, string serviceName)
            => _container.Register<TService>(factory => instance, serviceName: serviceName);

        /// <inheritdoc/>
        public void RegisterSingleton<TService>(TService instance, string serviceName)
            => _container.RegisterInstance<TService>(instance, serviceName: serviceName);

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Func<TArgument, TService> factory)
            => _container.Register(serviceFactory =>
            {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, new PerRequestLifeTime());

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Func<TArgument, TService> factory)
            => _container.Register(serviceFactory => {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, new PerScopeLifetime());

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Func<TArgument, TService> factory)
            => _container.Register(serviceFactory => {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, new PerContainerLifetime());

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Func<TArgument, TService> factory, string serviceName)
            => _container.Register(serviceFactory =>
            {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, serviceName);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Func<TArgument, TService> factory, string serviceName)
            => _container.Register(serviceFactory =>
            {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, serviceName, new PerScopeLifetime());

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Func<TArgument, TService> factory, string serviceName)
            => _container.Register(serviceFactory => {
                var arg = serviceFactory.GetInstance<TArgument>();
                return factory(arg);
            }, serviceName, new PerContainerLifetime());

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.GetInstance<TService>();

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


