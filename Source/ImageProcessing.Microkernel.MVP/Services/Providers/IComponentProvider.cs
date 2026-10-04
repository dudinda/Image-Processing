using System;

using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;

namespace ImageProcessing.Microkernel.MVP.Services.Providers
{
    /// <summary>
    /// Provides access to the specified
    /// DI container within the <seealso cref="AppController"/>.
    /// </summary>
    public interface IComponentProvider : IDisposable
    {
        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransient<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScoped<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the signleton <typeparamref name="TService"/>  as <typeparamref name="TImplementation"/>
        /// with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers a concrete type as a service
        /// with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransient<TService>();

        /// <summary>
        /// Registers a concrete type as a service
        /// with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingleton<TService>();

        /// <summary>
        /// Registers a concrete type as a service with
        /// the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScoped<TService>();

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/> with the transient scope.
        /// </summary>
        IComponentProvider RegisterNamedTransient<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/> as a named
        /// <typeparamref name="TImplementation"/>  with the caller-name scope.
        ///</summary>
        IComponentProvider RegisterNamedScoped<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/>  as a named
        /// <typeparamref name="TImplementation"/> with the singleton scope.
        /// </summary>
        IComponentProvider RegisterNamedSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransientInstance<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScopedInstance<TService>(TService instance);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> instance
        /// with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingletonInstance<TService>(TService instance);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransientNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScopedNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> instance
        /// with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingletonNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransient<TService>(Func<IComponentProvider, TService> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScoped<TService>(Func<IComponentProvider, TService> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the dependencies of the service with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingleton<TService>(Func<IComponentProvider, TService> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the transient scope.
        /// </summary>
        IComponentProvider RegisterTransient<TService>(Func<IComponentProvider, TService> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the caller-name scope.
        /// </summary>
        IComponentProvider RegisterScoped<TService>(Func<IComponentProvider, TService> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the singleton scope.
        /// </summary>
        IComponentProvider RegisterSingleton<TService>(Func<IComponentProvider, TService> factory, string name);

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
