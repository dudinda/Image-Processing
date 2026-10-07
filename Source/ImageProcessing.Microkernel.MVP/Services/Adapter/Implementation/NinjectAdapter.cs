using System;

using Ninject;
using Ninject.Extensions.NamedScope;

namespace ImageProcessing.Microkernel.MVP.Services.Adapter.Implementation
{
    /// <summary>
    /// Provides access to the Ninject <see cref="StandardKernel"/>
    /// via the <see cref="IContainerAdapter"/>.
    /// </summary>
    internal sealed class NinjectAdapter : IContainerAdapter
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
        public void RegisterTransient<TService, TArgument>(Func<TArgument, TService> factory)
            => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InTransientScope();

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Func<TArgument, TService> factory)
             => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InCallScope();

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Func<TArgument, TService> factory)
            => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InSingletonScope();

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
                   .InCallScope()
                   .Named(serviceName);

        /// <inheritdoc/>
        public void RegisterTransient<TService, TArgument>(Func<TArgument, TService> factory, string name)
            => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InTransientScope()
                    .Named(name);

        /// <inheritdoc/>
        public void RegisterScoped<TService, TArgument>(Func<TArgument, TService> factory, string name)
            => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InCallScope()
                    .Named(name);

        /// <inheritdoc/>
        public void RegisterSingleton<TService, TArgument>(Func<TArgument, TService> factory, string name)
             => _container
                    .Bind<TService>()
                    .ToMethod(context =>
                    {
                        var arg = context.Kernel.Get<TArgument>();
                        return factory(arg);
                    })
                    .InSingletonScope()
                    .Named(name);

        /// <inheritdoc/>
        public TService Resolve<TService>()
            => _container.Get<TService>();

        /// <summary>
        /// Dispose the Ninject container.
        /// </summary>
        public void Dispose()
            => _container.Dispose();

        /// <inheritdoc/>
        public bool IsRegistered<TService>()
            => _container.CanResolve<TService>();

        public IDisposable BeginScope()
        {
            if (_container == null)
            {
                throw new ArgumentNullException(nameof(_container));
            }

            return _container.BeginBlock();
        }
    }
}
