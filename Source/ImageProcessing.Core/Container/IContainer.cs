using System;
using System.Linq.Expressions;

namespace ImageProcessing.Core.Container
{
    /// <summary>
    /// Provides access to the specified
    /// DI container.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Registers the <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// </summary>
        void Register<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the signleton <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// </summary>
        void RegisterSingleton<TService, TImplementation>()
            where TImplementation : TService;

        /// <summary>
        /// Registers the named signleton <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// </summary>
        void RegisterSingleton<TService, TImplementation>(string serviceName)
            where TImplementation : TService;

        /// <summary>
        /// Registers a concrete type as a service.
        /// </summary>
        void Register<TService>();

        /// <summary>
        /// Registers a concrete type as a singleton service.
        /// </summary>
        void RegisterSingleton<TService>();

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given instance.
        /// </summary>
        void RegisterInstance<TService>(TService instance);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> with the given instance.
        /// </summary>
        void RegisterInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/>with the factory that describes.
        /// the dependencies of the service.
        /// </summary>
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/>as singleton with the factory that describes
        /// the dependencies of the service.
        /// </summary>
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as singleton with the factory that describes
        /// the named dependencies of the service.
        /// </summary>
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Get an instance of the given <typeparamref name="TService"/> type.
        /// </summary>
        TService Resolve<TService>();

        /// <summary>
        /// Returns <b>true</b> if the container can create the requested service, otherwise <b>false</b>.
        /// </summary>
        bool IsRegistered<TService>();

        /// <summary>
        /// Enable annotated dependency injection via constructor.
        /// </summary>
        void EnableAnnotatedConstructorInjection();
    }

}
