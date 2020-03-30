using System;
using System.Linq.Expressions;

using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.IoC.Interface
{
    /// <summary>
    /// Provides access to the specified
    /// DI container within the <seealso cref="AppController"/>.
    /// </summary>
    public interface IDependencyResolution : IDisposable
    {
        /// <summary>
        /// Register the <typeparamref name="TView"/> as <typeparamref name="TImplementation"/> with a transient scope.
        /// <para>Where the <typeparamref name="TImplementation"/> is a <typeparamref name="TView"/>  or <see langword="class"/>,
        /// and a <typeparamref name="TView"/> is a <see cref="IView"/>.</para>
        /// <para><b>Returns:</b> The current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterTransientView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView;

        /// <summary>
        /// Register the <typeparamref name="TView"/> as <typeparamref name="TImplementation"/> with the singleton scope.
        /// <para>Where the <typeparamref name="TImplementation"/> is a <typeparamref name="TView"/>  or <see langword="class"/>,
        /// and <typeparamref name="TView"/> is a <see cref="IView"/>.</para>
        /// <para><b>Returns:</b> The current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterSingletonView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView;

        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransient<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScoped<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the signleton <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers a concrete type as a service
        /// with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransient<TService>();

        /// <summary>
        /// Registers a concrete type as a service
        /// with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingleton<TService>();

        /// <summary>
        /// Registers a concrete type as a service with
        /// the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScoped<TService>();

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/> with the transient scope.
        /// </summary>
        IDependencyResolution RegisterNamedTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/>  with the caller-name scope.
        ///</summary>
        IDependencyResolution RegisterNamedScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/>  as a named
        /// <typeparamref name="TImplementation"/> with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterNamedSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransientInstance<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScopedInstance<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingletonInstance<TService>(TService instance);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransientNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScopedNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingletonNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransientFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScopedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the dependencies of the service with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingletonFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the transient scope.
        /// </summary>
        IDependencyResolution RegisterTransientNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the caller-name scope.
        /// </summary>
        IDependencyResolution RegisterScopedNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the singleton scope.
        /// </summary>
        IDependencyResolution RegisterSingletonNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Enable annotated dependency injection via constructor.
        /// </summary>
        IDependencyResolution EnableAnnotatedConstructorInjection();

        /// <summary>
        /// Returns <b>true</b> if the container can create the requested service, otherwise <b>false</b>.
        /// </summary>
        bool IsRegistered<TService>();

        /// <summary>
        /// Get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        TService Resolve<TService>();
    }
}
