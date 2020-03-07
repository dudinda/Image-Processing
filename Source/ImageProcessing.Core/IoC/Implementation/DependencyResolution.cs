using System;
using System.Linq.Expressions;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.IoC.Interface;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.IoC.Implementation
{
    /// <inheritdoc cref="IDependencyResolution"/>
    public class DependencyResolution : IDependencyResolution
    {
        private readonly IContainer _container;

        public DependencyResolution(IContainer container)
        {
            _container = Requires.IsNotNull(container, nameof(container));
        }

        /// <inheritdoc cref="IDependencyResolution.EnableAnnotatedConstructorInjection"/>
        public IDependencyResolution EnableAnnotatedConstructorInjection()
        {
            _container.EnableAnnotatedConstructorInjection();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.IsRegistered{TService}"/>
        public bool IsRegistered<TService>()
        {
            return _container.IsRegistered<TService>();
        }

        /// <inheritdoc cref="IDependencyResolution.Register{TService, TImplementation}"/>
        public IDependencyResolution Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.Register{TService}"/>
        public IDependencyResolution Register<TService>()
        {
            _container.Register<TService>();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.Register{TService, TArgument}(Expression{Func{TArgument, TService}})"/>
        public IDependencyResolution Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.Register(factory);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterInstance{TService}(TService)"/>
        public IDependencyResolution RegisterInstance<TService>(TService instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterNamedInstance{TService}(TService, string)"/>
        public IDependencyResolution RegisterNamedInstance<TService>(TService instance, string serviceName)
        {
            _container.RegisterInstance(instance, serviceName);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterNamedSingleton{TService, TImplementation}(string)"/>
        public IDependencyResolution RegisterNamedSingleton<TService, TImplementation>(string serviceName) where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>(serviceName);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterSingleton{TService, TImplementation}"/>
        public IDependencyResolution RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _container.RegisterSingleton<TService, TImplementation>();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterSingleton{TService}"/>
        public IDependencyResolution RegisterSingleton<TService>()
        {
            _container.RegisterSingleton<TService>();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterSingleton{TService, TArgument}(Expression{Func{TArgument, TService}})"/>
        public IDependencyResolution RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.RegisterSingleton(factory);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterSingleton{TService, TArgument}(Expression{Func{TArgument, TService}}, string)"/>
        public IDependencyResolution RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string serviceName)
        {
            _container.RegisterSingleton(factory, serviceName);
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.RegisterView{TView, TImplementation}"/>
        public IDependencyResolution RegisterView<TView, TImplementation>()
            where TView : IView
            where TImplementation : class, TView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        /// <inheritdoc cref="IDependencyResolution.Resolve{TService}"/>
        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
    }
}
