using System;

using ImageProcessing.Microkernel.MVP.Code.Constants;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Presenter;
using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Services.Factories;

namespace ImageProcessing.Microkernel.MVP.Models.State.Implementation
{
    /// <summary>
    /// An application has not been built state.
    /// </summary>
    internal sealed class AppIsNotBuilt : IAppState
    {
        private readonly AppLifecycle _app;
        private readonly AdapterFactory _adapter = new AdapterFactory();

        public AppIsNotBuilt(AppLifecycle app)
        {
            _app = app;
        }

        /// <inheritdoc/>
        public void Build<TStartup>(DiContainer container)
            where TStartup : class, IStartup
        {
            try
            {
                _app.Controller = new AppController(_adapter.GetAdapter(container));

                var ioc = _app.Controller.IoC;

                if (ioc.IsRegistered<TStartup>())
                {
                    throw new InvalidOperationException(
                        Exceptions.StartupIsDefined);
                }

                ioc.RegisterSingleton<TStartup>()
                   .Resolve<TStartup>().Build(ioc);

                _app.State = _app.Factory.GetState(AppState.IsBuilt);
            }
            catch(Exception ex)
            {
                _app.State = _app.Factory.GetState(AppState.EndWork);
                throw;
            }
     
        }

        /// <inheritdoc/>
        public void Exit()
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt);

        /// <inheritdoc/>
        public void Run<TMainPresenter>()
            where TMainPresenter : class, IPresenter
            => throw new InvalidOperationException(
                Exceptions.ApplicationIsNotBuilt);
    }
}
