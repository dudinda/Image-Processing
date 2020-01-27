﻿using System;
using System.Linq.Expressions;

using ImageProcessing.Core.Container;

using LightInject;

namespace ImageProcessing.Core.Adapters.LightInject
{
    public class LightInjectAdapter : IContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        /// <summary>
        /// Registers the <c>TService</c> with the <c>TImplementation</c>.
        /// </summary>
        public void Register<TService, TImplementation>() where TImplementation : TService
            => _container.Register<TService, TImplementation>();

        /// <summary>
        /// Registers the <c>TService</c> with the <c>TImplementation</c>.
        /// </summary>
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
            => _container.Register<TService, TImplementation>(new PerContainerLifetime());


        /// <summary>
        /// Registers the <c>TService</c> with the named <c>TImplementation</c>.
        /// </summary>
        public void RegisterSingleton<TService, TImplementation>(string name) where TImplementation : TService
            => _container.Register<TService, TImplementation>(name, new PerContainerLifetime());

        /// <summary>
        /// Registers a concrete type of a service.
        /// </summary>
        public void Register<TService>()
            => _container.Register<TService>();

        /// <summary>
        /// Registers a concrete type of a service.
        /// </summary>
        public void RegisterSingleton<TService>()
            => _container.Register<TService>(new PerContainerLifetime());


        /// <summary>
        /// Registers the <c>TService</c> with the given instance.
        /// </summary>
        public void RegisterInstance<T>(T instance)
            => _container.RegisterInstance(instance);
        

        /// <summary>
        /// Registers the TService with the factory that describes.
        /// the dependencies of the service
        /// </summary>
        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => _container.Register(serviceFactory => factory);

        /// <summary>
        /// Registers the TService as singleton with the factory that describes
        /// the dependencies of the service 
        /// </summary>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
            => _container.Register(serviceFactory => factory, new PerContainerLifetime());

        /// <summary>
        /// Registers the TService as singleton with the factory that describes
        /// the named dependencies of the service 
        /// </summary>
        public void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name)
            => _container.Register(serviceFactory => factory, name, new PerContainerLifetime());

        /// <summary>
        /// Get an instance of the given <c>TService</c> type.
        /// </summary>
        public TService Resolve<TService>()
            => _container.GetInstance<TService>();
        

        public void EnableAnnotatedConstructorInjection()
            => _container.EnableAnnotatedConstructorInjection();

        /// <summary>
        /// Returns <b>true</b> if the container can create the requested service, otherwise <b>false</b>.
        /// </summary>
        public bool IsRegistered<TService>()
            => _container.CanGetInstance(typeof(TService), string.Empty);
        
    }
}
