using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Adapters.LightInject;
using ImageProcessing.Core.Adapters.Ninject;
using ImageProcessing.Core.Container;
using ImageProcessing.Core.Controller.Implementation;
using ImageProcessing.Core.EntryPoint.Interface;
using ImageProcessing.Core.Presenter;

namespace ImageProcessing.Core.EntryPoint
{
    public static class AppStart
    {
        private static AppController _controller;
        private static bool _isBuilt;

        public static void BuildContainer(DiContainer container)
        {
            _controller = new AppController(GetContainerAdapter());

            IContainer GetContainerAdapter() => container
                switch
            {
                DiContainer.LightInject
                    => new LightInjectAdapter(),
                DiContainer.Ninject
                    => new NinjectAdapter(),

                _ => throw new NotImplementedException(nameof(container))
            };

            _isBuilt = true;
        }

        public static void UseStartup<TStartup>()
            where TStartup : class, IStartup
        {
            if (!_isBuilt)
            {
                throw new InvalidOperationException("The application is not built.");
            }

            if(_controller.IoC.IsRegistered<TStartup>())
            {
                throw new InvalidOperationException("The specified startup is already defined.");
            }

            _controller.IoC.RegisterSingleton<TStartup>();

            _controller.IoC
                .Resolve<TStartup>()
                .Build(_controller.IoC);
        }

        public static void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
        {
            if(!_isBuilt)
            {
                throw new InvalidOperationException("The application is not built.");
            }

            _controller.Run<TMainPresenter>();
        }

        public static void Exit()
        {
            if(!_isBuilt)
            {
                throw new InvalidOperationException("The application is not built.");
            }

            _controller.Dispose();
        }
    }
}
