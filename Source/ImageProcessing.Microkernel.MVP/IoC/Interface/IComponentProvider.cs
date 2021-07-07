using System;
using System.Linq.Expressions;

using ImageProcessing.Microkernel.MVP.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.Microkernel.MVP.IoC.Interface
{
    /// <summary>
    /// Provides access to the specified
    /// DI container within the <seealso cref="AppController"/>.
    /// </summary>
    public interface IComponentProvider : IDisposable
    {
        /// <summary>
        /// Register the <typeparamref name="TView"/> as <typeparamref name="TImplementation"/> with a transient scope.
        /// <para>Where the <typeparamref name="TImplementation"/> is a <typeparamref name="TView"/>  or <see langword="class"/>,
        /// and a <typeparamref name="TView"/> is a <see cref="IView"/>.</para>
        /// <para><b>Returns:</b> The current instance of <see cref="IComponentProvider"/>.</para>
        /// </summary>
        [Obsolete("The implementation will be removed. Please, use RegisterTransient instead.")]
        IComponentProvider RegisterTransientView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView;

        /// <summary>
        /// Register the <typeparamref name="TView"/> as <typeparamref name="TImplementation"/> with the singleton scope.
        /// <para>Where the <typeparamref name="TImplementation"/> is a <typeparamref name="TView"/>  or <see langword="class"/>,
        /// and <typeparamref name="TView"/> is a <see cref="IView"/>.</para>
        /// <para><b>Returns:</b> The current instance of <see cref="IComponentProvider"/>.</para>
        /// </summary>
        [Obsolete("The implementation will be removed. Please, use RegisterSingleton instead.")]
        IComponentProvider RegisterSingletonView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView, IDisposable;

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
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterTransientFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes.
        /// the dependencies of the service with the caller-name scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterScopedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the dependencies of the service with the singleton scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterSingletonFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the transient scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterTransientNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the caller-name scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterScopedNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as the factory that describes
        /// the named dependencies of the service with the singleton scope.
        /// </summary>
        [Obsolete("The implementation will not be provided. Will be removed.")]
        IComponentProvider RegisterSingletonNamedFactory<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

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
