using System;

using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models.State;
using ImageProcessing.Microkernel.MVP.Models.State.Implementation;

namespace ImageProcessing.Microkernel.MVP.Services.Factories
{
    /// <summary>
    /// A factory method for all the types
    /// implementing the <see cref="IAppState"/>.
    /// </summary>
    internal class StateFactory
    {
        private readonly AppLifecycle _app;
        public StateFactory(AppLifecycle app)
        {
            _app = app;
        }
        /// <summary>
        /// Get the specified <see cref="AppState"/>.
        /// </summary>
        internal IAppState GetState(AppState state)
            => state
        switch
        {
            AppState.IsBuilt
                => new AppIsBuilt(_app),
            AppState.IsNotBuilt
                => new AppIsNotBuilt(_app),
            AppState.StartWork
                => new AppStartWork(_app),
            AppState.EndWork
                => new AppEndWork(_app),

            _ => throw new NotImplementedException(nameof(state))
        };
    }
}
