using System;

using ImageProcessing.Microkernel.MVP.Services.Adapter;

namespace ImageProcessing.Microkernel.MVP.Services.Providers.Implementation
{
    /// <inheritdoc cref="IComponentProvider"/>
    public class ComponentProvider : IComponentProvider
    {
        /// <inheritdoc cref="IContainerAdapter"/>
        private readonly IContainerAdapter _container;

        public ComponentProvider(IContainerAdapter container)
        {
            _container = container ??
                throw new ArgumentException(nameof(container));
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransient<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterTransient<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScoped<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterScoped<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransient<TService>()
        {
            _container.RegisterTransient<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingleton<TService>()
        {
            _container.RegisterSingleton<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScoped<TService>()
        {
            _container.RegisterScoped<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterNamedTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterTransient<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterNamedScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterScoped<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterNamedSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransientInstance<TService>(TService instance)
        {
            _container.RegisterTransient(instance);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScopedInstance<TService>(TService instance)
        {
            _container.RegisterScoped(instance);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingletonInstance<TService>(TService instance)
        {
            _container.RegisterSingleton(instance);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransientNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterTransient(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScopedNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterScoped(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingletonNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterSingleton(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransient<TService>(
            Func<IComponentProvider, TService> factory)
        {
            _container.RegisterTransient(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScoped<TService>(
            Func<IComponentProvider, TService> factory)
        {
            _container.RegisterScoped(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingleton<TService>(
            Func<IComponentProvider, TService> factory)
        {
            _container.RegisterSingleton(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransient<TService>(
            Func<IComponentProvider, TService> factory, string name)
        {
            _container.RegisterTransient(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScoped<TService>(
            Func<IComponentProvider, TService> factory, string name)
        {
            _container.RegisterScoped(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingleton<TService>(
            Func<IComponentProvider, TService> factory, string name)
        {
            _container.RegisterSingleton(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public bool IsRegistered<TService>()
            => _container.IsRegistered<TService>();

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.Resolve<TService>();

        /// <summary>
        /// Performs the disposing of the specified
        /// <see cref="IContainerAdapter"/>.
        /// </summary>
        public void Dispose()
            => _container.Dispose();

        /// <inheritdoc/>
        public IDisposable BeginScope()
            => _container.BeginScope();
    }
}
