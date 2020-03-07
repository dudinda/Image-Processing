using System;
using System.Linq.Expressions;

using ImageProcessing.Core.View;

namespace ImageProcessing.Core.IoC.Interface
{
    /// <summary>
    /// Provides access to the specified
    /// Di container within the <seealso cref="AppController"/>.
    /// </summary>
    public interface IDependencyResolution
    {
        /// <summary>
        /// Register the <typeparamref name="TView"/> with the <typeparamref name="TImplementation"/>
        /// <para>Where the <typeparamref name="TImplementation"/> is a <typeparamref name="TView"/>  or <see langword="class"/>, and <typeparamref name="TView"/> is a <see cref="IView"/>.</para>
        /// <para><b>Returns:</b> The current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView;

        /// <summary>
        /// Registers the <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// <para><b>Returns:</b> Current instance of the <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution Register<TService, TImplementation>() where TImplementation : TService;

        /// <summary>
        /// Registers the singleton <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// <para><b>Returns:</b> Current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterSingleton<TService, TImplementation>() where TImplementation : TService;

        /// <summary>
        /// Registers the named singleton <typeparamref name="TService"/>  with the <typeparamref name="TImplementation"/>.
        /// </summary>
        IDependencyResolution RegisterNamedSingleton<TService, TImplementation>(string serviceName) where TImplementation : TService;

        /// <summary>
        /// Registers a concrete type as a service.
        /// <para><b>Returns:</b> Current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution Register<TService>();

        /// <summary>
        /// Registers a concrete type as a singleton service.
        /// <para><b>Returns:</b> Current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterSingleton<TService>();

        /// <summary>
        /// Registers the <typeparamref name="TService"/> with the given instance.
        /// <para><b>Returns:</b> The current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterInstance<TService>(TService instance);

        /// <summary>
        /// Registers the named <typeparamref name="TService"/> with the given instance.
        /// <para><b>Returns:</b> Current instance of <see cref="IDependencyResolution"/>.</para>
        /// </summary>
        IDependencyResolution RegisterNamedInstance<TService>(TService instance, string serviceName);

        /// <summary>
        /// Registers the <typeparamref name="TService"/>with the factory that describes.
        /// the dependencies of the service.
        /// </summary>
        IDependencyResolution Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/>as singleton with the factory that describes
        /// the dependencies of the service.
        /// </summary>
        IDependencyResolution RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> as singleton with the factory that describes
        /// the named dependencies of the service.
        /// </summary>
        IDependencyResolution RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);

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
