using System;
using System.Linq.Expressions;

using ImageProcessing.Microkernel.DIAdapter.Container;
using ImageProcessing.Microkernel.MVP.IoC.Interface;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.Microkernel.MVP.IoC.Implementation
{
    /// <inheritdoc cref="IComponentProvider"/>
    internal sealed class ComponentProvider : IComponentProvider
    {
        /// <inheritdoc cref="IContainer"/>
        private readonly IContainer _container;

        public ComponentProvider(IContainer container)
        {
            if(container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            _container = container;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransientView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView
        {
            _container.RegisterTransient<TView, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingletonView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView, IDisposable
        {
            _container.RegisterSingleton<TView, TImplementation>();
            return this;
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
        public IComponentProvider RegisterTransientFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterTransient(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScopedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterScoped(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingletonFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterSingleton(factory);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterTransientNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
        {
            _container.RegisterTransient(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterScopedNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
        {
            _container.RegisterScoped(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IComponentProvider RegisterSingletonNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
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
        /// <see cref="IContainer"/>.
        /// </summary>
        public void Dispose()
            => _container.Dispose();
    }
}
