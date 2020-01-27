using System;
using System.Linq.Expressions;

namespace ImageProcessing.Core.Container
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;
        void RegisterSingleton<TService, TImplementation>(string name) where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>();
        bool IsRegistered<TService>();
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
        void RegisterSingleton<TService, TArgument>(Expression<Func<TArgument, TService>> factory, string name);
        void EnableAnnotatedConstructorInjection();
    }

}
