using System;
using System.Linq.Expressions;

namespace ImageProcessing.Microkernel.DIAdapter.Adapters.Interface
{
    /// <summary>
    /// Provides access to the specified
    /// DI container.
    /// </summary>
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with a transient scope.
        /// </summary>
        void RegisterTransient<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the caller-name scope.
        /// </summary>
        void RegisterScoped<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the signleton <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with a singleton scope.
        /// </summary>
        void RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers a concrete type as a service
        /// with a transient scope.
        /// </summary>
        void RegisterTransient<TService>();

        /// <summary>
        /// Registers a concrete type as a service
        /// with a singleton scope.
        /// </summary>
        void RegisterSingleton<TService>();

        /// <summary>
        /// Registers a concrete type as a service with
        /// the caller-name scope.
        /// </summary>
        void RegisterScoped<TService>();

        /// <summary>
        /// Registers the named singleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/> with a transient scope.
        /// </summary>
        void RegisterTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named singleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/>  with the caller-name scope.
        ///</summary>
        void RegisterScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/>  as a named
        /// <typeparamref name="TImplementation"/> with a singleton scope.
        /// </summary>
        void RegisterSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with a transient scope.
        /// </summary>
        void RegisterTransient<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        void RegisterScoped<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with a singleton scope.
        /// </summary>
        void RegisterSingleton<TService>(TService instance);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with a transient scope.
        /// </summary>
        void RegisterTransient<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        void RegisterScoped<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with a singleton scope.
        /// </summary>
        void RegisterSingleton<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with a transient scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the caller-name scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the dependencies of the service with a singleton scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with a transient scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterTransient<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the caller-name scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterScoped<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with a singleton scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

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
