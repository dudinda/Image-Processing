using System;
using System.Linq.Expressions;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.DI.Container;
using ImageProcessing.Core.DI.IoC.Interface;
using ImageProcessing.Core.MVP.View;

namespace ImageProcessing.Core.DI.IoC.Implementation
{
    /// <inheritdoc cref="IDependencyResolution"/>
    internal sealed class DependencyResolution : IDependencyResolution
    {
        /// <inheritdoc cref="IContainer"/>
        private readonly IContainer _container;

        public DependencyResolution(IContainer container)
        {
            _container = Requires.IsNotNull(
                container, nameof(container)
            );
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransientView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView
        {
            _container.RegisterTransient<TView, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingletonView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView
        {
            _container.RegisterSingleton<TView, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransient<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterTransient<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScoped<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterScoped<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransient<TService>()
        {
            _container.RegisterTransient<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingleton<TService>()
        {
            _container.RegisterSingleton<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScoped<TService>()
        {
            _container.RegisterScoped<TService>();
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterNamedTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterTransient<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterNamedScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterScoped<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterNamedSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransientInstance<TService>(TService instance)
        {
            _container.RegisterTransient(instance);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScopedInstance<TService>(TService instance)
        {
            _container.RegisterScoped(instance);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingletonInstance<TService>(TService instance)
        {
            _container.RegisterSingleton(instance);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransientNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterTransient(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScopedNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterScoped(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingletonNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterSingleton(instance, serviceName);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransientFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterTransient(factory);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScopedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterScoped(factory);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingletonFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterSingleton(factory);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterTransientNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
        {
            _container.RegisterTransient(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterScopedNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
        {
            _container.RegisterScoped(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution RegisterSingletonNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
        {
            _container.RegisterSingleton(factory, name);
            return this;
        }

        /// <inheritdoc/>
        public IDependencyResolution EnableAnnotatedConstructorInjection()
        {
            _container.EnableAnnotatedConstructorInjection();
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
